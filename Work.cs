using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscreteMathLab2
{
    public class Propertie
    {
        public string text { get; set; }
        public bool isPropertie { get; set; }

        public Propertie(string text, bool isPropertie)
        {
            this.text = text;
            this.isPropertie = isPropertie;
        }
    }
    internal class Work
    {
        private Propertie[] properties;
        int _size;
        bool[,] matrix;

        public Work(int size)
        {
            _size = size;
            matrix = new bool[size, size];
        }

        void newProperies()
        {
            properties = new Propertie[]
            {
                new Propertie("рефлексивное", isReflection),
                new Propertie("антирефлексивное", isAntiReflection),
                new Propertie("симметричное", isSymmetric),
                new Propertie("анти-симметричное", isAntiSymmetric),
                new Propertie("асимметричное", isAsymmetric),
                new Propertie("транзитивное", isTransitive),
                new Propertie("полное(связное)", isCompletence)

            };
        }

        public void StringToInt(string[] rows)
        {
            if (rows == null || rows.Length != _size) return;
            for (int i = 0; i < _size; i++)
            {
                string[] rowWithNum = rows[i].Split(' ');
                for (int j = 0; j < _size; j++)
                {
                    matrix[i, j] = Convert.ToBoolean(int.Parse(rowWithNum[j]));
                }
            }
            newProperies();
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine();
                for(int j = 0; j < _size; j++)
                {
                    Console.Write($"{matrix[i, j], 3:F0} ");
                }
            }
        }

        public void Show()
        {
            string result = "Матрица не создана";
            if (properties != null)
            {
                result = "Отношение: ";
                foreach(var item in properties)
                {
                    if (item.isPropertie)
                        result += $"{item.text}, ";
                }
            }
            result = result.TrimEnd(' ', ',') + ".";
            Console.WriteLine(result);
        }

        public bool isReflection => this.Reflection();
        private bool Reflection()
        {
            for(int i = 0; i < _size; i++)
            {
                if (!matrix[i, i])
                    return false;
            }
            return true;
        }
        
        public bool isAntiReflection => this.AntiReflection();
        private bool AntiReflection()
        {
            for (int i = 0; i < _size; i++)
            {
                if (matrix[i, i])
                    return false;
            }
            return true;
        }

        public bool isSymmetric => this.Symmetric();
        private bool Symmetric()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                        return false;
                }
            }
            return true;
        }

        public bool isAntiSymmetric => this.AntiSymmetric();
        private bool AntiSymmetric()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    if (matrix[i, j] == matrix[j, i])
                        return false;
                }
            }
            return true;
        }

        public bool isTransitive => this.Transitive();
        private bool Transitive()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (matrix[i, j])
                    {
                        for (int k = 0; k < _size; k++)
                        {
                            if (matrix[j, k] && !matrix[i, k])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool isCompletence => this.Completence();
        private bool Completence()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (i != j && matrix[i, j]) 
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isAsymmetric => isAntiReflection && isAntiSymmetric;
        
    }
}
