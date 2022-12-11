using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExcel
{
    internal static class FileWorker
    {
        internal static void SaveAs()
        {
            SaveFileDialog saveFile = new()
            {
                Filter = "Json-file|*.json",
                Title = "Save as"
            };

            saveFile.ShowDialog();

            Save(saveFile.FileName);
            Data.Path = saveFile.FileName;
        }
        internal static void Save(string path)
        {
            try
            {
                if (path == null)
                {
                    MessageBox.Show("Не вдається знайти шлях. Спробуйте зберегти цей файл через 'Save as'.");
                }
                else
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.LatinExtendedA),
                        WriteIndented = true
                    };

                    string serializedFile = JsonSerializer.Serialize(Data.cellsList, options);
                    File.WriteAllText(path, serializedFile);
                    MessageBox.Show("Файл було збережено!");
                }
            }
            catch (SerializationException)
            {
                MessageBox.Show("Помилка серіалізації файлу.");
            }
            catch
            {
                MessageBox.Show("Не вдалось зберегти файл.");
            }
        }
        internal static void OpenFile()
        {
            OpenFileDialog openFile = new()
            {
                Filter = "Json-file|*.json",
                Title = "Open as"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Data.Path = openFile.FileName;

                try
                {
                    var jsonContent = File.ReadAllText(Data.Path);

                    Data.cellsList = JsonSerializer.Deserialize<List<List<DataCell>>>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (CheckFileWholeness() == false)
                    {
                        MessageBox.Show("Файл пошкоджений.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Не вдалось десеріалізувати файл.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Файл не було обрано.");
                return;
            }
        }
        internal static bool CheckFileWholeness()   //Перевіряємо цілісність json-файлу (чи правильно вказані всі індекси)
        {
            int cellInList = 0;

            for (int row = 0; row < Data.cellsList.Count; row++)    //Заповнюємо клітинки значеннями
            {
                for (int col = 0; col < Data.cellsList[row].Count; col++)
                {
                    cellInList++;
                    if (Data.cellsList[row][col].Row != row || Data.cellsList[row][col].Column != col)
                    {
                        return false;
                    }
                    Data.cellsList[row][col].SetName();
                }
            }
            int numOfCells = Data.cellsList.Count * Data.cellsList[0].Count;  //Перевіряємо наявність всіх клітин у json-файлі

            if (numOfCells != cellInList)
            {
                return false;
            }

            if (Data.cellsList[0].Count > 25)   //Макс. кількість стовпчиків: 26
            {
                return false;
            }

            return true;
        }
    }
}
