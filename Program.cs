using library;
using System.Reflection;

// загружаем нашу сборку
Assembly theAssembly = Assembly.Load(new AssemblyName("lab07"));

// добавляем текст в файл
void AppendXML(string output)
{
    File.AppendAllText("D:\\C#\\lab07\\lab07\\AssemblyInfo.xml", output + "\n");
}

// очищаем файл и начинаем заполнять
File.Delete("D:\\C#\\lab07\\lab07\\AssemblyInfo.xml");
AppendXML("<Lab07>");
AppendXML(theAssembly.FullName);



// для каждого типа в сборке
foreach (Type definedType in theAssembly.ExportedTypes)
{
    // если это клас
    if (definedType.GetTypeInfo().IsClass)
    {
        // записываем имя класс и его предка
        AppendXML($"\n<class> {definedType.Name} : {definedType.BaseType}");
        // получаем его атрибуты
        IEnumerable<MyAttribute> attributes = definedType.GetTypeInfo().GetCustomAttributes().OfType<MyAttribute>().ToArray();
        // если они есть то пишем комментарий
        if (attributes.Count() > 0)
        {
            foreach (MyAttribute attribute in attributes)
            {
                AppendXML($"<comment>{attribute.Comment}</comment>");
            }
        }
        // выводим информацию о методах
        foreach (MethodInfo method in definedType.GetMethods())
        {
            AppendXML($"<method>{(method.IsStatic ? "static " : "")}{(method.IsVirtual ? "virtual " : "")}{method.ReturnType.Name} {method.Name} ()</method>");
        }
        AppendXML("</class>");//завершаем запись класса
    }
}

AppendXML("</Lab07>");//завершаем запись проекта
