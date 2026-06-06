// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Aqui Importo la libreria que me dara aceso a crear la tabla
//Agregar colores, los bordes 
using System;   
using Spectre.Console;


class Program
//Aqui ya estamos aplicando lo que Programacion Orientada a Objetos
//Asi mismo como dice class program, quiere decir que esa es la clase principal

{
    static void Main(string[] args)
    //Aca especialmente empeze con el main, ya que aqui digo que quiero que empice en este lugar

    {
        var datos = CapturarDatos();

       
        decimal cuotaFija = CalcularCuota(datos.montoPrestamo, datos.interesAnual, datos.plazo);

        var tabla = GenerarTabla(datos.montoPrestamo, datos.interesAnual, datos.plazo, cuotaFija);

       
        MostrarResultados(tabla);
    }


    static (decimal montoPrestamo, decimal interesAnual, int plazo) CapturarDatos()
    {
        //Aca uso uno de varias herramientas que permite usar Spectre
        //Le doy color a las letrar, pido tambien que el usuario ingrese los datos
        AnsiConsole.MarkupLine("[green]Ingrese el monto del préstamo:[/]");
        decimal monto = decimal.Parse(Console.ReadLine()!);

        AnsiConsole.MarkupLine("[yellow]Ingrese el interés anual (%):[/]");
        decimal interes = decimal.Parse(Console.ReadLine()!);

        AnsiConsole.MarkupLine("[red]Ingrese el plazo del préstamo (meses):[/]");
        int plazo = int.Parse(Console.ReadLine()!);

        return (monto, interes, plazo);
    }

  
    static decimal CalcularCuota(decimal monto, decimal interesAnual, int plazo)
    {
        decimal interesMensual = (interesAnual / 12) / 100;

        decimal n = (decimal)System.Math.Pow(1 + (double)interesMensual, plazo);
        decimal d = n - 1;

        decimal cuota = monto * interesMensual * (n / d);

        return System.Math.Round(cuota, 2);
    }


    static Table GenerarTabla(decimal monto, decimal interesAnual, int plazo, decimal cuotaFija)
    // Aqui es donde utilizo el codigo para generar la tabla con sus columnas 
    //Utlizo la formala dada para poder tener el resultado pedido
    {
        decimal interesMensual = (interesAnual / 12) / 100;
        decimal saldo = monto;

        var table = new Table()
            .RoundedBorder()
            .BorderColor(Color.Green)
            .Title("[yellow bold]TABLA DE AMORTIZACIÓN[/]");

        table.AddColumn("[yellow]Período[/]", col => col.Centered());
        table.AddColumn("[green]Cuota[/]", col => col.Centered());
        table.AddColumn("[red]Interés[/]", col => col.Centered());
        table.AddColumn("[blue]Abono Capital[/]", col => col.Centered());
        table.AddColumn("[gray]Saldo[/]", col => col.Centered());

        for (int i = 1; i <= plazo; i++)
        {
            decimal interesPeriodo = System.Math.Round(saldo * interesMensual, 2);
            decimal abonoCapital = System.Math.Round(cuotaFija - interesPeriodo, 2);

            saldo -= abonoCapital;
            saldo = System.Math.Round(saldo, 2);

            //Ulilizo esto para que no me den numeros negativos

            if (saldo < 0)
                saldo = 0;
                // Mayormente ulizo para darle formato a los numeros use N2 que es para los decimales
                // pero otro caso seria F2 y C 
            table.AddRow(
                i.ToString(),
                cuotaFija.ToString("N2"),
                interesPeriodo.ToString("N2"),
                abonoCapital.ToString("N2"),
                saldo.ToString("N2")
            );
        }

        return table;
    }


    static void MostrarResultados(Table tabla)
    {
        //Para crear la tabla
        AnsiConsole.Write(tabla);
        //Aca hago que me imprima esto al final cuando termine todo 
        AnsiConsole.MarkupLine("\n[green bold]Cálculo finalizado correctamente.[/]");
    }
}