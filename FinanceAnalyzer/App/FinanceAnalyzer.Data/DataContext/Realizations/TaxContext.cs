namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using MapStrategies = FinanceAnalyzer.Data.Mappers.DoubleCollectionMapStrategies;

    public class TaxContext : ITaxContext<decimal>
    {
        private const string FilePath = "tax.txt";

        public async Task ClearAll()
        {
            await File.WriteAllTextAsync(FilePath, string.Empty);
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            using (var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var data = await streamReader.ReadToEndAsync();
                    return MapStrategies.MapDecimalCollection(data);
                }
            }
        }

        public Task<IReadOnlyCollection<decimal>> GetAllByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<decimal> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Save(decimal obj)
        {
            using (var streamWriter = new StreamWriter(FilePath, true, Encoding.Default))
            {
                await streamWriter.WriteLineAsync(obj.ToString());
            }
        }
    }
}
