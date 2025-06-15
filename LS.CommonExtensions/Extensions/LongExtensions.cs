
namespace LS.CommonExtensions.Extensions
{
    public static class LongExtensions
    {
        public static string ToFileSizeString(this long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            double size = bytes;

            while (size >= 1024 && i < suffix.Length - 1)
            {
                size /= 1024;
                i++;
            }
            return $"{size:N2} {suffix[i]}";
        }
    }
}
