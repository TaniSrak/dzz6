using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzz6
{

    public class Foo
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // название
        public string Description { get; set; } //описнаие

    }

    public class Bar
    {
        public Guid Id { get; set; }
        public string Title { get; set; } //заголовок
        public string Description { get; set; }
    }

    public static class StringPropertyAnalyzer //анализатор строковых свойств
    {
        //расчет средней длины строковых свойств
        public static Dictionary<string, double> CalculateAverageStringLength(IEnumerable<object> objects)
        {
            var result = new Dictionary<string, double>(); //словарь для хранения результата
            var groupedPbjects = objects.GroupBy(o => o.GetType()); //группировка по типам

            foreach (var group in groupedPbjects) //обработка групп
            {
                var type = group.Key; //тип группы
                var properties=type.GetProperties().Where(p => p.PropertyType == typeof(string)); //свойства типа

                int totalLength = 0; //длина
                int totalCount = 0; //количества

                foreach (var o in group) //обработка объекта в группе
                { 
                    foreach (var property in properties) //обработка его строкового свойства
                    {
                        var value = property.GetValue(o) as string; //значение
                        if (value != null) 
                        { 
                            totalLength += value.Length; //добавляем длину строки к общей длине
                            totalCount++; // > счетчика свойств
                        }

                    }
                }
                result[type.Name] = totalCount == 0 ? 0 : (double)totalLength / totalCount;

            }
            return result;
        }
    }
}
