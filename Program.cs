namespace WinFormsApp;
using Schemmas;

static class Program
{
    [STAThread]
    static void Main()
    {
        // Inicializa o programa
        ApplicationConfiguration.Initialize();
        Schemma.buildTableDb();
        Application.Run(new SelectTypeUser());
    }
}