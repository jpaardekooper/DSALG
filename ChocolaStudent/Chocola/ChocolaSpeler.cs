using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chocola
{
    abstract class ChocolaSpeler
    {
        public string Naam { get; protected set; }
        
        /// <summary>
        /// Doet een verstandige zet voor deze speler. Roept aan het eind HandleZet aan met de gekozen zet in een Point
        /// </summary>
        /// <param name="bord">De huidige speltoestand</param>
        /// <param name="sizeX">De breedte van het bord</param>
        /// <param name="sizeY">De hoogte van het bord</param>
        public abstract void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY);
        
        public delegate void ZetGedaanHandler(Point zet);
        public event ZetGedaanHandler OnZetGedaan;

        /// <summary>
        /// Verwerkt een gekozen zet en geeft de beurt door
        /// </summary>
        /// <param name="zet">de gekozen set</param>
        protected void HandleZet(Point zet)
        {
            if (OnZetGedaan != null)
            {
                OnZetGedaan(zet);
            }
        }

        /// <summary>
        /// Geeft de naam van het algoritme
        /// </summary>
        /// <returns>de naam van het algoritme</returns>
        public override string ToString()
        {
            return Naam;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ChocolaSpeler()
        {
            Naam = "<standaard>";
        }
    }
}

