using System.IO;
using System.Text;



static string Encrypt(string path, char key)
{
    using (StreamReader reader = new StreamReader(path))
    {
        string text = reader.ReadToEnd();
        string encryptedText;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var character in text)
        {
            stringBuilder.Append(character ^ key);
            Console.WriteLine(character ^ key);
        }
        encryptedText = stringBuilder.ToString();
        return encryptedText;
    }
}
static void WriteEncryptedText(string path, string text)
{
    using (StreamWriter writer = new StreamWriter(path))
    {
        writer.Write(text);
    }
}


string from = @"C:\Users\Gozel_ct64\Desktop\1\text.txt";
string to = @"C:\Users\Gozel_ct64\Desktop\2\2.txt";
char key = 'a';
string encryptedText;
ThreadPool.QueueUserWorkItem((o) => {
    encryptedText = Encrypt(from, key);
    WriteEncryptedText(to, encryptedText);
});
Encrypt(from, key);

Console.WriteLine("Successfully finished");