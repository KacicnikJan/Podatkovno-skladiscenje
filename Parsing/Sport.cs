using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing
{
    class Sport
    {
        private string ime_aktivnosti;

        private string cas_posnetka;

        private string trajanje_aktivnosti;

        private string stevilo_prevozenih_km;

        private string skupen_vzpon;

        private string porabljene_kalorije;

        private string povp_hitrost;

        private string povp_kadenca;

        private string max_kadenca;

        public string Ime_aktivnosti { get => ime_aktivnosti; set => ime_aktivnosti = value; }
        public string Cas_posnetka { get => cas_posnetka; set => cas_posnetka = value; }
        public string Trajanje_aktivnosti { get => trajanje_aktivnosti; set => trajanje_aktivnosti = value; }
        public string Stevilo_prevozenih_km { get => stevilo_prevozenih_km; set => stevilo_prevozenih_km = value; }
        public string Skupen_vzpon { get => skupen_vzpon; set => skupen_vzpon = value; }
        public string Porabljene_kalorije { get => porabljene_kalorije; set => porabljene_kalorije = value; }
        public string Povp_hitrost { get => povp_hitrost; set => povp_hitrost = value; }
        public string Povp_kadenca { get => povp_kadenca; set => povp_kadenca = value; }
        public string Max_kadenca { get => max_kadenca; set => max_kadenca = value; }

        public Sport()
        {
        
        }

        public Sport(string ime_aktivnosti, string cas_posnetka, string trajanje_aktivnost, string stevilo_prevozenih_km, string skupen_vzpon, string porabljene_kalorije, string povp_hitrost, string povp_kadenca, string max_kadenca)
        {
            this.Ime_aktivnosti = ime_aktivnosti;
            this.Cas_posnetka = cas_posnetka;
            this.Trajanje_aktivnosti = trajanje_aktivnost;
            this.Stevilo_prevozenih_km = stevilo_prevozenih_km;
            this.Skupen_vzpon = skupen_vzpon;
            this.Porabljene_kalorije = porabljene_kalorije;
            this.Povp_hitrost = povp_hitrost;
            this.Povp_kadenca = povp_kadenca;
            this.Max_kadenca = max_kadenca;
        }


    }
}
