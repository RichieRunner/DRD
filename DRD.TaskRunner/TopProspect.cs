using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRD.TaskRunner
{
    public class TopProspect
    {
        public Prospect_Players prospect_players { get; set; }
        public int year { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class Prospect_Players
    {
        public Pdp[] pdp { get; set; }
        public Draft[] draft { get; set; }
        public Atl[] atl { get; set; }
        public Nyy[] nyy { get; set; }
        public Cw[] cws { get; set; }
        public Sd[] sd { get; set; }
        public Mil[] mil { get; set; }
        public La[] la { get; set; }
        public Pit[] pit { get; set; }
        public Col[] col { get; set; }
        public Cin[] cin { get; set; }
        public Tb[] tb { get; set; }
        public Sf[] sf { get; set; }
        public Ari[] ari { get; set; }
        public Tex[] tex { get; set; }
        public Hou[] hou { get; set; }
        public Ana[] ana { get; set; }
        public Sea[] sea { get; set; }
        public Oak[] oak { get; set; }
        public Stl[] stl { get; set; }
        public Chc[] chc { get; set; }
        public Cle[] cle { get; set; }
        public Kc[] kc { get; set; }
        public Min[] min { get; set; }
        public Det[] det { get; set; }
        public Was[] was { get; set; }
        public Phi[] phi { get; set; }
        public Mia[] mia { get; set; }
        public Nym[] nym { get; set; }
        public Bal[] bal { get; set; }
        public Bo[] bos { get; set; }
        public Tor[] tor { get; set; }
        public Prospect[] prospects { get; set; }
        public Rhp[] rhp { get; set; }
        public Lhp[] lhp { get; set; }
        public C[] c { get; set; }
        public _1B[] _1b { get; set; }
        public _2B[] _2b { get; set; }
        public _3B[] _3b { get; set; }
        public Ss[] ss { get; set; }
        public Of[] of { get; set; }
    }

    public class Pdp
    {
        public string prospect_year { get; set; }
        public string player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public string preseason100 { get; set; }
        public string preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Draft
    {
        public string prospect_year { get; set; }
        public string player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public string preseason100 { get; set; }
        public string preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Atl
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Nyy
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Cw
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Sd
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Mil
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class La
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Pit
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Col
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Cin
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Tb
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Sf
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Ari
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public string preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Tex
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Hou
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Ana
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public string preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Sea
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Oak
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Stl
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Chc
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Cle
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Kc
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public string preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Min
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Det
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Was
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Phi
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Mia
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Nym
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Bal
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Bo
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Tor
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Prospect
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Rhp
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public int preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Lhp
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public int preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class C
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class _1B
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public object preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class _2B
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class _3B
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public object preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Ss
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public int preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }

    public class Of
    {
        public string prospect_year { get; set; }
        public int player_id { get; set; }
        public string player_first_name { get; set; }
        public string player_last_name { get; set; }
        public int rank { get; set; }
        public string position { get; set; }
        public int preseason100 { get; set; }
        public int preseason20 { get; set; }
        public string team_file_code { get; set; }
        public string thumb { get; set; }
        public string thumb62x75 { get; set; }
        public string thumb124x150 { get; set; }
        public string photo180x218 { get; set; }
        public string photo360x436 { get; set; }
    }



}
