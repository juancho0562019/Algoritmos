
namespace ConstructorRostro
{
    public class Rostrobuilder
    {
        private Rostro _rostro;

        public Rostrobuilder()
        {
            _rostro = new Rostro();
        }

        public Rostrobuilder AñadirOjos(string ojos)
        {
            _rostro.Ojos = ojos;
            return this;
        }

        public Rostrobuilder AñadirCejas(string cejas)
        {
            _rostro.Cejas = cejas;
            return this;
        }

        public Rostrobuilder AñadirNariz(string nariz)
        {
            _rostro.Nariz = nariz;
            return this;
        }

        public Rostrobuilder AñadirBoca(string boca)
        {
            _rostro.Boca = boca;
            return this;
        }

        public Rostrobuilder AñadirCabello(string cabello)
        {
            _rostro.Cabello = cabello;
            return this;
        }

        public Rostrobuilder AñadirOrejas(string orejas)
        {
            _rostro.Orejas = orejas;
            return this;
        }

        public Rostrobuilder AñadirContorno(string contorno)
        {
            _rostro.Contorno = contorno;
            return this;
        }

        public Rostrobuilder AñadirBarbilla(string barbilla)
        {
            _rostro.Barbilla = barbilla;
            return this;
        }

        public Rostro Build()
        {
            return _rostro;
        }
    }
}
