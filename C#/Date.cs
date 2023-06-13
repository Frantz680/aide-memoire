        string moisAbrégé = "apr";
        
        DateTime date = DateTime.ParseExact(moisAbrégé, "MMM", null);
        int moisEnNombre = date.Month;
        
        Console.WriteLine("Mois en nombre : " + moisEnNombre);
