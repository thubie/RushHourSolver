using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class StartStates
    {
        #region StartStates
        const string setup1 =   "555L01" +
                                "MAAL01" +
                                "M.XX01" +
                                "BBN..." +
                                ".ON.CC" +
                                ".OEEDD";

        const string setup2 =   "L..666" +
                                "L55501" +
                                "XXMN01" +
                                "AAMN01" +
                                "...OBB" +
                                ".CCO..";

        const string setup3 =   "555L0."+
                                "MAAL0."+
                                "M.XX0."+
                                "BBM..O"+
                                ".QNCCO"+
                                ".QEEDD";


        const string setup4 =   "...LBB"+
                                ".AALM."+
                                "XXNOM."+
                                "DDNOCC"+
                                "P.555Q"+
                                "P.666Q";


        const string setup5 =   "L..555"+
                                "L6660."+
                                "XXNO0M"+
                                "CCNO0M"+
                                "...LBB"+
                                ".AAL..";

        const string setup6 =   "AA0.M1"+
                                "..0.M1"+
                                "..0XX1"+
                                "...2BB"+
                                "LDD2.."+
                                "L..2CC";


        const string setup7 =   "0LAAN."+
                                "0LM.N1"+
                                "0.MXX1"+
                                "555O.1"+
                                "..POBB"+
                                "DDPCC.";


        const string setup8 =   "LAAMCC"+
                                "LBBM.."+
                                "XX0N.."+
                                "..0NDD"+
                                "..0EEP"+
                                "..FF.P";

        #endregion

        List<string>puzzles;
        public StartStates()
        {
            puzzles = new List<string>();
            puzzles.Add(setup1);
            puzzles.Add(setup2);
            puzzles.Add(setup3);
            puzzles.Add(setup4);
            puzzles.Add(setup5);
            puzzles.Add(setup6);
            puzzles.Add(setup7);
            puzzles.Add(setup8);
        }
                                    
        public string getPuzzle(int puzzle)
        {
            int index = puzzle;
            return puzzles[index];
        }                
                                    
                                    
                                    
    }
}
