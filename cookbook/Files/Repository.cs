using System.Text.Json;


namespace cookbook.Files
{
    public interface IStringsRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }


    public class StringsJsonRepository : StringsRepository
    {
        protected override string StringsToText(List<string> strings)
        {
            return JsonSerializer.Serialize(strings);
        }

        protected override List<string> TextToStrings(string fileContents)
        {
            return JsonSerializer.Deserialize<List<string>>(fileContents);
        }
    }


    public abstract class StringsRepository : IStringsRepository
    {
        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return TextToStrings(fileContents);
            }
            return new List<string>();
        }

        protected abstract List<string> TextToStrings(string fileContents);

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringsToText(strings));
        }

        protected abstract string StringsToText(List<string> strings);
    }

    public class StringsTextualRepository : StringsRepository
    {
        private static readonly string Separator = Environment.NewLine;

        protected override string StringsToText(List<string> strings)
        {
            return string.Join(Separator, strings);
        }

        protected override List<string> TextToStrings(string fileContents)
        {
            return fileContents.Split(Separator).ToList();
        }
    }

}