

string first_number = "9999";
string second_number = "888";

List<int> products = new List<int>();


foreach (var c in first_number){

    int first = Int32.Parse(c.ToString());

    foreach(var d in second_number){

        int second = Int32.Parse(d.ToString());
        // Console.WriteLine("aaaa");
        products.Add(first * second);
    }
    
}

Console.WriteLine("kjlj");
Console.WriteLine(products.Count);


foreach (var i in products){
    Console.WriteLine(i);
}