using ApiBiblioteca.DTO;
using Owin;



namespace ApiBiblioteca
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Se configura el db context para que sea usado como una única instancia por request
            app.CreatePerOwinContext(Context.Create);
        }
    }
}
