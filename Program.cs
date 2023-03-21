// See https://aka.ms/new-console-template for more information
int opcion;
Dictionary<string,int> DicRegalos = new Dictionary<string, int>();
do
{
    Console.Clear();
    Console.WriteLine("1. Ingresar Importes de un curso");
    Console.WriteLine("2. Ver Estadísticas de Regalos");
    Console.WriteLine("3. Salir");
    opcion = IngresarEnteroEnRango("Elija opción: ", 1, 3);
    Console.Clear();
    switch (opcion)
    {
        case 1:
            IngresarImportesCurso();
            break;
        case 2:
            VerEstadisticas();
            break;
    }
} while (opcion != 3);

void IngresarImportesCurso()
{
    string CursoIngresar = IngresarTexto("Ingrese el curso que regalará ");
    if(DicRegalos.ContainsKey(CursoIngresar)) 
    {
        Console.WriteLine("Este curso ya cargo los regalos de sus alumnos");
        Console.ReadLine();
    }
    else
    {
        int CantAlumnos = IngresarEntero("Ingrese la cantidad de Alumnos del curso " + CursoIngresar + " ");
        int Importes = IngresarImportes(CantAlumnos);
        DicRegalos.Add(CursoIngresar,Importes);
    }
}

int IngresarImportes(int CantAlumnos)
{
    int Acum=0;
    for(int i=0; i<CantAlumnos; i++)
    {
        int ImporteAlumno = IngresarEntero("Ingrese importe del alumno " + (i+1) + " ");
        Acum += ImporteAlumno;
    }
    return Acum;
}
void VerEstadisticas()
{
    if (DicRegalos.Count>0)
    {
        int CursoMayorImporte = 0;
        string CursoMayor = "";
        int RecaudacionTotal=0;
        foreach(string Curso in DicRegalos.Keys)
        {
            if (CursoMayorImporte<DicRegalos[Curso])
            {
                CursoMayorImporte = DicRegalos[Curso];
                CursoMayor = Curso;
            }
            RecaudacionTotal += DicRegalos[Curso];
        }

        Console.WriteLine("El curso que mas plata puso fue " + CursoMayor + " con " + CursoMayorImporte);
        Console.WriteLine("El promedio regalado de cursos fue " + RecaudacionTotal / DicRegalos.Count);
        Console.WriteLine("La recaudacion total asciende a " + RecaudacionTotal);
        Console.WriteLine("La cantidad de cursos que participan del regalo son " + DicRegalos.Count);
    }
    else Console.WriteLine("Aun no hay cursos cargados");
    Console.ReadLine();

}

int IngresarEntero(string msj)
{
    int entero=-1;
    while (entero == -1)
    {   
        Console.Write(msj);
        int.TryParse(Console.ReadLine(), out entero);
    }
    return entero;
}
string IngresarTexto(string msj)
{
    string texto = "";
    while (texto == "")
    {
        Console.Write(msj);
        texto = Console.ReadLine();
    }
    return texto;
}

int IngresarEnteroEnRango(string msj, int minimo, int maximo)
{
    int entero;
    entero = IngresarEntero(msj);
    while (entero < minimo || entero > maximo)
    {
        entero = IngresarEntero("ERROR! " + msj);
    }
    return entero;
}