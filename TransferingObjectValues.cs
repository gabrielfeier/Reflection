void Main()
{
	var m1 = new MyObject1
	{
		Name = "Gabriel",
		ListName = new List<string> {"item1", "item2", "item3"},
	};
	
	var m2 = new MyObject2();
		
	var asdf = m1.ConvertObjectTo(m2);
	
	asdf.Dump();
}

public class MyObject1
{
	public string Name { get; set; }
	public List<string> ListName {get;set;}
}

public class MyObject2
{
	public string Name { get; set; }
	public List<string> ListName {get;set;}
}

public static class ObjectExtensions
{
	public static object ConvertObjectTo<T>(this T obj, object obj2)
    {
        try
        {
            var arrayProperties = obj.GetType().GetProperties();
            var arrayProperties2 = obj2.GetType().GetProperties();

            foreach (var _ in arrayProperties)
            {
                foreach (var x in arrayProperties2)
                {
                    var comparedAttributes = _.PropertyType == x.PropertyType && _.Name == x.Name;
					
					if(comparedAttributes)
						x.SetValue(obj2, _.GetValue(obj, null), null);
				}
			}
			return obj2;
		}
		catch
		{
			return null;
		}
	}
}
