using System.IO.Compression;

string srcDir = @"olddir";
string dstDir = @"newdir";
string fileZip = @"archive.zip";

//ZipFile.CreateFromDirectory(srcDir, fileZip);
//Console.WriteLine("Directory add to archive");
//ZipFile.ExtractToDirectory(fileZip, dstDir);
//Console.WriteLine("New directory from archive");

using(FileStream stream = File.Open(fileZip, FileMode.Open))
{
    using(ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Update))
    {
        ZipArchiveEntry entry = archive.CreateEntry("myfile.txt");
        using(StreamWriter writer = new StreamWriter(entry.Open()))
        {
            writer.WriteLine("Hello world");
        }
    }
}