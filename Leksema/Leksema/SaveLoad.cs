using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Leksema
{
    class SaveLoad
    {
        static string filename;
        public static string Load()
        {
            string s = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Текстовый файл|*.txt|Все файлы|*.*";
            if (open.ShowDialog() == DialogResult.OK)
                try
                {
                    filename = open.FileName;
                    s = File.ReadAllText(filename, Encoding.Default);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка открытия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            return s;
        }

        public static void Save(string s)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = true;
            save.Filter = "Текстовый файл|*.txt|Все файлы|*.*";
            save.FileName = "Файл";
            if (save.ShowDialog() == DialogResult.OK)
                try
                {
                    filename = save.FileName;
                    File.WriteAllText(filename, s, Encoding.Default);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить файл", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

    }
}
