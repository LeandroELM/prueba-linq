using LinQ12;

var bees = new List<Cerveza> 
{
    new Cerveza { nombre = "Mahou", pais = "España", tipo = "Lager", precio = 0.70 },
    new Cerveza { nombre = "Estrella", pais = "España", tipo = "Lager", precio = 0.75 },
    new Cerveza { nombre = "Alhambra", pais = "España", tipo = "Lager", precio = 0.80 },
    new Cerveza { nombre = "Guinness", pais = "Irlanda", tipo = "Stout", precio = 1.20 },
    new Cerveza { nombre = "Heineken", pais = "Holanda", tipo = "Lager", precio = 0.90 },
    new Cerveza { nombre = "Paulaner", pais = "Alemania", tipo = "Lager", precio = 1.10 },
    new Cerveza { nombre = "Pilsner Urquell", pais = "Republica Checa", tipo = "Lager", precio = 1.00 },
    new Cerveza { nombre = "Kozel", pais = "Republica Checa", tipo = "Lager", precio = 0.90 },
    new Cerveza { nombre = "Budweiser", pais = "EEUU", tipo = "Lager", precio = 0.80 },
    new Cerveza { nombre = "Anchor Steam", pais = "EEUU", tipo = "Lager", precio = 1.00 },
    new Cerveza { nombre = "Samuel Adams", pais = "EEUU", tipo = "Lager", precio = 1.10 },
    new Cerveza { nombre = "Cruzcampo", pais = "España", tipo = "Lager", precio = 0.60 },
    new Cerveza { nombre = "San Miguel", pais = "España", tipo = "Lager", precio = 0.65 },
    new Cerveza { nombre = "Amstel", pais = "Holanda", tipo = "Lager", precio = 0.70 },
    new Cerveza { nombre = "Damm", pais = "España", tipo = "Lager", precio = 0.60 }
};

var brands = new List<marca> 
{
    new marca { nombre = "leandro", color = "Rojo" },
    new marca { nombre = "lacayo", color = "Verde" },
    new marca { nombre = "matus", color = "Rojo" },
    
};

//seleccionar nombre y precio de las cervezas de españa
var names_precio = from b in bees
                   where b.pais == "España"
                   orderby b.precio ascending
            select new { b.nombre, b.precio };
//ordeanar
var ordenar = from b in bees
              orderby b.precio descending
           select b.nombre ;
//agrupar por tipo
var tipos = from b in bees
            group b by b.pais into g
            select new 
            {
                tipo = g.Key,
                count = g.Count()
            };
//unir dos listas
var union = from b in bees
            join m in brands on b.nombre equals m.nombre
            select new 
            {
                nombre = b.nombre,
                pais = b.pais,
                color = m.color 
            };

foreach (var contar in tipos) 
{
    Console.WriteLine(contar.tipo + " " + contar.count);
}
Console.WriteLine("------------------------------------------------------");
foreach (var p in names_precio)
{
    Console.WriteLine($"Nombre: {p.nombre} y precio: {p.precio}");
}
Console.WriteLine("------------------------------------------------------");
foreach (var p in ordenar)
{
    Console.WriteLine($"Nombre: {p}");
}
Console.WriteLine("------------------------------------------------------");
foreach (var p in union)
{
    Console.WriteLine($"Nombre: {p.nombre} y pais: {p.pais} y color: {p.color}");
}
Console.WriteLine("------------------------------------------------------");

/