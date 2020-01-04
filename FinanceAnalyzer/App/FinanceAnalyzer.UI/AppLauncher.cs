namespace FinanceAnalyzer.UI
{
    using System;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.Shared.Enums;
    using FinanceAnalyzer.Shared.Exceptions;
    using FinanceAnalyzer.UI.Interfaces;

    internal class AppLauncher : ILauncher
    {
        private const int MaxAttemptsNumber = 3;

        private readonly IFinanceService<decimal> _financeService;
        private readonly IDataReceiver _dataReceiver;
        private readonly ILoginService _loginService;
        private readonly ICookieManager _cookieManager;
        private readonly IDisplayer _displayer;

        private User _currentUser;
        private bool _isAppOn;

        public AppLauncher(
            IFinanceService<decimal> financeService,
            IDataReceiver dataReceiver,
            ILoginService loginService,
            ICookieManager authorizer,
            IDisplayer displayer)
        {
            _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
            _dataReceiver = dataReceiver ?? throw new ArgumentNullException(nameof(dataReceiver));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _cookieManager = authorizer ?? throw new ArgumentNullException(nameof(authorizer));
            _displayer = displayer ?? throw new ArgumentNullException(nameof(displayer));

            _isAppOn = true;
        }

        public async Task Launch()
        {
            await InitializeCurrentUser();

            while (_isAppOn)
            {
                _displayer.DisplayStartMenu();
                await PerformAction(_dataReceiver.GetAction());
            }
        }

        private async Task PerformAction(ActionType action)
        {
            switch (action)
            {
                case ActionType.DisplayIncome:
                    _displayer.DisplayIncome(await _financeService.GetIncomeHistory());
                    break;
                case ActionType.DisplayExpenses:
                    _displayer.DisplayExpenses(await _financeService.GetExpenseHistory());
                    break;
                case ActionType.DisplayFullInformation:
                    _displayer.DisplayFullInformation(await _financeService.GetFullInformation());
                    break;
                case ActionType.AddNewIncome:
                    await AddNewIncome();
                    break;
                case ActionType.AddNewExpense:
                    await AddNewExpense();
                    break;
                case ActionType.ClearHistory:
                    await _financeService.ClearHistory();
                    break;
                case ActionType.Exit:
                    TurnOffApp();
                    break;
                case ActionType.Logout:
                    await _cookieManager.DeleteCookies();
                    TurnOffApp();
                    break;
                default:
                    break;
            }
        }

        private async Task AddNewIncome()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter new income", isClearAll: true);
                if (_dataReceiver.TryGetDecimal(out var inputResult))
                {
                    await _financeService.AddNewIncome(inputResult);
                    return;
                }

                _displayer.DisplayErrorMessage("Try again :(");
            }

            _displayer.DisplayNotification("Ended typing attempts");
        }

        private async Task AddNewExpense()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter new expense", isClearAll: true);
                if (_dataReceiver.TryGetDecimal(out var inputResult))
                {
                    await _financeService.AddNewExpense(inputResult);
                    return;
                }

                _displayer.DisplayErrorMessage("Try again :(");
            }

            _displayer.DisplayNotification("Ended typing attempts");
        }

        private async Task InitializeCurrentUser()
        {
            var cookieUser = await _cookieManager.GetUserFromCookie();
            _currentUser = cookieUser == null
                ? null
                : await _loginService.Login(cookieUser.Login, cookieUser.Password);

            if (_currentUser == null)
            {
                await OpenLoginMenu();
            }
        }

        private async Task LoginInApp() // Знаю что пока этот метод, и тот что ниже одинаковые, потом придумаю как всё это вынести в одно место
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter your login", true);
                string loginString = _dataReceiver.GetString();

                _displayer.DisplayMessage("Enter your password", isOnFreePlace: true);
                string passwordString = _dataReceiver.GetString(isOnFreePlace: true);

                if (loginString == null
                    && passwordString == null)
                {
                    continue;
                }

                var user = await _loginService.Login(loginString, passwordString);

                if (user != null)
                {
                    await _cookieManager.SaveUserCookie(user);
                    _currentUser = user;
                    return;
                }

                _displayer.DisplayNotification("Try again :(");
            }

            _currentUser = default;
        }

        private async Task RegisterInApp()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter your login", true);
                string loginString = _dataReceiver.GetString();

                _displayer.DisplayMessage("Enter your password", isOnFreePlace: true);
                string passwordString = _dataReceiver.GetString(isOnFreePlace: true);

                if (loginString == null
                    && passwordString == null)
                {
                    continue;
                }

                var user = await _loginService.Register(loginString, passwordString);

                if (user != null)
                {
                    await _cookieManager.SaveUserCookie(user);
                    _currentUser = user;
                    return;
                }

                _displayer.DisplayNotification("Try again :(");
            }

            _currentUser = default;
        }

        private async Task OpenLoginMenu()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayLoginMenu();

                if (_dataReceiver.TryGetInt(out int result, isOnFreePlace: true))
                {
                    switch (result)
                    {
                        case 1:
                            await LoginInApp();
                            return;
                        case 2:
                            await RegisterInApp();
                            return;
                        default:
                            break;
                    }
                }
            }
        }

        private void TurnOffApp()
        {
            _isAppOn = false;
        }
    }
}
