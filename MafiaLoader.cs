using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mafia
{
    /// <summary>
    /// リソースをStreamを介して読み込む。
    /// </summary>
    public class MafiaLoader
    {
        private static MafiaLoader defaultLoader;

        private string resourceName;

        static MafiaLoader()
        {
            defaultLoader = new MafiaLoader(Mafia.RESOURCE_NAME);
        }

        public MafiaLoader(string resourceName)
        {
            this.resourceName = resourceName;
        }

        public static MafiaLoader DefaultLoader
        {
            get
            {
                return defaultLoader;
            }
        }

        public FileStream GetFileStream(string fileName)
        {
            if (fileName.IndexOf(':') != -1)
            {
                return new FileStream(fileName, FileMode.Open);
            }

            var path = Path.Combine(GetExeDirectory(), resourceName, fileName);
            return new FileStream(path, FileMode.Open);
        }

        public Texture2D GetTexture(GraphicsDevice device, string fileName)
        {
            var path = Path.Combine(GetExeDirectory(), resourceName, fileName);
            return Texture2D.FromFile(device, path);
        }

        /*
        public SecondaryBuffer GetBuffer(Microsoft.DirectX.DirectSound.Device device, string fileName)
        {
            BufferDescription bd = new BufferDescription();
            bd.ControlEffects = false;
            bd.ControlPan = true;
            bd.ControlVolume = true;
            return new SecondaryBuffer(GetFileStream(fileName), bd, device);
        }
        */

        public Stage GetStage(string fileName)
        {
            Stream stream = GetFileStream(fileName);
            StreamReader reader = new StreamReader(stream);
            string title = null;
            int numRows = 0;
            int numCols = 0;
            try
            {
                title = reader.ReadLine();
                numRows = int.Parse(reader.ReadLine());
                numCols = int.Parse(reader.ReadLine());
            }
            catch (FormatException)
            {
                throw new Exception(fileName + " の書式に致命的なミスがあるっぽいです＞＜");
            }
            catch (OverflowException)
            {
                throw new Exception(fileName + " で何か途方もなく巨大な面を作ろうとしてませんか＞＜");
            }
            string[] source = new string[numRows];
            for (int row = 0; row < numRows; row++)
            {
                source[row] = reader.ReadLine();
            }
            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            return new Stage(fileName, title, numRows, numCols, source);
        }

        private static string GetExeDirectory()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        }
    }
}
