namespace FoodService.Models
{
    public class FileManager
    {               //!!!!!
        public static Task CopyAsync(IFormFile file,string path)
        {
            return Task.Run(() =>
            {
                using (var stream = file.OpenReadStream())
                {
                    byte[] bytes = new byte[stream.Length + 32];
                    int numBytesToRead = (int)stream.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = stream.Read(bytes, numBytesRead, 32);
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    File.WriteAllBytes(path, bytes);
                }
            });
        }
    }
}
