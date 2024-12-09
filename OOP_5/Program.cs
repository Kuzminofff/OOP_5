using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class Element
    {
        public Element() { }
        public string name;
        public bool operand1;
        public bool operand2;
        public bool result;
        public virtual void setResult() { } //виртуальная функция для потомков
    };
    public class AND : Element
    {
        public AND() { }
        public override void setResult()
        {
            result = operand1 && operand2;
        }
    };


    public class OR : Element
    {
        public OR() { }
        public override void setResult()
        {
            result = operand1 || operand2;
        }
    };

    public class Scheme
    {
        public Scheme() { }
        public Element[] DATA = new Element[10];
        public void createElement(int index, string type, string name)
        {
            if (type == "and")
                DATA[index] = new AND();
            if (type == "or")
                DATA[index] = new OR();

            DATA[index].name = name;
        }
        public void readData()
        {
            StreamReader sr = new StreamReader("inputData.txt");

            int i = 0;
            string line;
            while (!sr.EndOfStream) //конец файла
            {
                line = sr.ReadLine();
                if (i < 10)
                {
                    string[] ln = line.Split('	'); // split - для разделения строки line в массив строк ln по разделителю табуляции  одинарные ковычки из-за типа разделителя char 
                    if (ln.Count() == 2) //count кол-во элементов в массиве строк ln
                    {
                        if (ln[0] == "true")
                            DATA[i].operand1 = true;
                        else
                            DATA[i].operand1 = false;
                        if (ln[1] == "true")
                            DATA[i].operand2 = true;
                        else
                            DATA[i].operand2 = false;
                    }
                    else
                    {
                        if (ln[0] == "true")
                            DATA[i].operand1 = true;
                        else
                            DATA[i].operand1 = false;
                        if (i > 0)
                        {
                            DATA[i].operand2 = DATA[i - 1].result;
                        }
                    }
                    DATA[i].setResult();
                }
                i++;
            }
        }

    };
    class Program
    {
        static void Main(string[] args)
        {
            Scheme sc = new Scheme();
            sc.createElement(0, "and", "and");
            sc.createElement(1, "or", "or");
            sc.createElement(2, "and", "and");
            sc.createElement(3, "or", "or");
            sc.createElement(4, "and", "and");
            sc.createElement(5, "or", "or");
            sc.createElement(6, "and", "and");
            sc.createElement(7, "or", "or");
            sc.createElement(8, "and", "and");
            sc.createElement(9, "or", "or");
            sc.readData();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"name: {sc.DATA[i].name}   operand1: {sc.DATA[i].operand1}    operand2: { sc.DATA[i].operand2}    Результат: {sc.DATA[i].result}");
            }
            Console.ReadLine();
        }
    }
}
