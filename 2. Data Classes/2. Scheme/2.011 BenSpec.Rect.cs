using PTXClassLibrary;
using System;

public class BenSpecRect : BenSpec
{
    // Additional constructor for BenSpecRect
    public BenSpecRect(string name, string id, string description)
        : base(name, id, description)
    {
        RectSetup();
    }

    // Default constructor for BenSpecRect
    public BenSpecRect()
    {
        RectSetup();
    }

    // Private function to set up categories, retirement ages, and tranches
    private void RectSetup()
    {
        // Add categories
        Category ReTrancheCat = new Category { ID = "ReTrancheCat" };
        Categories.Add(ReTrancheCat);


        // Set retirement ages for ReTrancheCat
        ReTrancheCat.RetirementAges.PreBarberNRA_F = 60;
        ReTrancheCat.RetirementAges.PreBarberNRA_M = 65;
        ReTrancheCat.RetirementAges.BBtoEqnNRA_M = 63;
        ReTrancheCat.RetirementAges.BBtoEqnNRA_F = 63;
        ReTrancheCat.RetirementAges.PostBBNRA = 65;
        ReTrancheCat.Equalisation.BarberEndDate = new DateTime(1995, 5, 5);
        DateTime EqnDate = ReTrancheCat.Equalisation.BarberEndDate;
        DateTime EqnDateM1 = EqnDate.AddDays(-1);
        DateTime BBDate = new DateTime(1990, 5, 17);
        DateTime BBDateM1 = BBDate.AddDays(-1);


        // Define Standard Tranches
        Tranche tranPre88GMP = new Tranche("Pre88GMP", "Pre88GMP", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche tranPost88GMP = new Tranche("Post88GMP", "Post88GMP", new DateTime(1988, 4, 6), new DateTime(1997, 4, 5));
        Tranche tranPre97XS1 = new Tranche("Pre97XS1", "Pre97XS1", new DateTime(1970, 1, 1), new DateTime(1985, 12, 31));
        Tranche tranPre97XS2 = new Tranche("Pre97XS2", "Pre97XS2", new DateTime(1986, 1, 1), new DateTime(1994, 11, 1));
        Tranche tranPre97XS3 = new Tranche("Pre97XS3", "Pre97XS3", new DateTime(1994, 11, 2), new DateTime(2000, 12, 31));

        // Add tranches to ReTrancheCat
        ReTrancheCat.Tranches.Add(tranPre88GMP);
        ReTrancheCat.Tranches.Add(tranPost88GMP);
        ReTrancheCat.Tranches.Add(tranPre97XS1);
        ReTrancheCat.Tranches.Add(tranPre97XS2);
        ReTrancheCat.Tranches.Add(tranPre97XS3);



        // Define Default base and Date Split tranches
        Tranche reTran78to88ScmPre88GMP = new Tranche("reTran78to88ScmPre88GMP", "reTran78to88ScmPre88GMP", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran78to88StatPre88GMP = new Tranche("reTran78to88StatPre88GMP", "reTran78to88StatPre88GMP", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran78to88Pre88GMPasXS1 = new Tranche("reTran78to88Pre88GMPasXS1", "reTran78to88Pre88GMPasXS1", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran78to88Pre88GMPasXS2 = new Tranche("reTran78to88Pre88GMPasXS2", "reTran78to88Pre88GMPasXS2", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran78to88Pre88GMPasXS3 = new Tranche("reTran78to88Pre88GMPasXS3", "reTran78to88Pre88GMPasXS3", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran88toBBScmPost88GMP = new Tranche("reTran88toBBScmPost88GMP", "reTran88toBBScmPost88GMP", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnScmPost88GMP = new Tranche("reTranBBtoEqnScmPost88GMP", "reTranBBtoEqnScmPost88GMP", BBDate, EqnDateM1);

        Tranche reTranEqnto97ScmPost88GMP = new Tranche("reTranEqnto97ScmPost88GMP", "reTranEqnto97ScmPost88GMP", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran88toBBStatPost88GMP = new Tranche("reTran88toBBStatPost88GMP", "reTran88toBBStatPost88GMP", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnStatPost88GMP = new Tranche("reTranBBtoEqnStatPost88GMP", "reTranBBtoEqnStatPost88GMP", BBDate, EqnDateM1);

        Tranche reTranEqnto97StatPost88GMP = new Tranche("reTranEqnto97StatPost88GMP", "reTranEqnto97StatPost88GMP", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran88toBBPost88GMPasXS1 = new Tranche("reTran88toBBPost88GMPasXS1", "reTran88toBBPost88GMPasXS1", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnPost88GMPasXS1 = new Tranche("reTranBBtoEqnPost88GMPasXS1", "reTranBBtoEqnPost88GMPasXS1", BBDate, EqnDateM1);

        Tranche reTranEqnto97Post88GMPasXS1 = new Tranche("reTranEqnto97Post88GMPasXS1", "reTranEqnto97Post88GMPasXS1", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran88toBBPost88GMPasXS2 = new Tranche("reTran88toBBPost88GMPasXS2", "reTran88toBBPost88GMPasXS2", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnPost88GMPasXS2 = new Tranche("reTranBBtoEqnPost88GMPasXS2", "reTranBBtoEqnPost88GMPasXS2", BBDate, EqnDateM1);

        Tranche reTranEqnto97Post88GMPasXS2 = new Tranche("reTranEqnto97Post88GMPasXS2", "reTranEqnto97Post88GMPasXS2", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran88toBBPost88GMPasXS3 = new Tranche("reTran88toBBPost88GMPasXS3", "reTran88toBBPost88GMPasXS3", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnPost88GMPasXS3 = new Tranche("reTranBBtoEqnPost88GMPasXS3", "reTranBBtoEqnPost88GMPasXS3", BBDate, EqnDateM1);

        Tranche reTranEqnto97Post88GMPasXS3 = new Tranche("reTranEqnto97Post88GMPasXS3", "reTranEqnto97Post88GMPasXS3", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran78to88Pre97XS1 = new Tranche("reTran78to88Pre97XS1", "reTran78to88Pre97XS1", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran78to88Pre97XS2 = new Tranche("reTran78to88Pre97XS2", "reTran78to88Pre97XS2", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran78to88Pre97XS3 = new Tranche("reTran78to88Pre97XS3", "reTran78to88Pre97XS3", new DateTime(1978, 4, 6), new DateTime(1988, 4, 5));
        Tranche reTran88toBBPre97XS1 = new Tranche("reTran88toBBPre97XS1", "reTran88toBBPre97XS1", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnPre97XS1 = new Tranche("reTranBBtoEqnPre97XS1", "reTranBBtoEqnPre97XS1", BBDate, EqnDateM1);

        Tranche reTranEqnto97Pre97XS1 = new Tranche("reTranEqnto97Pre97XS1", "reTranEqnto97Pre97XS1", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran88toBBPre97XS2 = new Tranche("reTran88toBBPre97XS2", "reTran88toBBPre97XS2", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnPre97XS2 = new Tranche("reTranBBtoEqnPre97XS2", "reTranBBtoEqnPre97XS2", BBDate, EqnDateM1);

        Tranche reTranEqnto97Pre97XS2 = new Tranche("reTranEqnto97Pre97XS2", "reTranEqnto97Pre97XS2", EqnDate, new DateTime(1997, 4, 5));
        Tranche reTran88toBBPre97XS3 = new Tranche("reTran88toBBPre97XS3", "reTran88toBBPre97XS3", new DateTime(1988, 4, 6), BBDateM1);
        Tranche reTranBBtoEqnPre97XS3 = new Tranche("reTranBBtoEqnPre97XS3", "reTranBBtoEqnPre97XS3", BBDate, EqnDateM1);
        Tranche reTranEqnto97Pre97XS3 = new Tranche("reTranEqnto97Pre97XS3", "reTranEqnto97Pre97XS3", EqnDate, new DateTime(1997, 4, 5));

        // Add default base tranches to ReTrancheCat
        ReTrancheCat.Tranches.Add(reTran78to88ScmPre88GMP);
        ReTrancheCat.Tranches.Add(reTran78to88StatPre88GMP);
        ReTrancheCat.Tranches.Add(reTran78to88Pre88GMPasXS1);
        ReTrancheCat.Tranches.Add(reTran78to88Pre88GMPasXS2);
        ReTrancheCat.Tranches.Add(reTran78to88Pre88GMPasXS3);
        ReTrancheCat.Tranches.Add(reTran88toBBScmPost88GMP);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnScmPost88GMP);
        ReTrancheCat.Tranches.Add(reTranEqnto97ScmPost88GMP);
        ReTrancheCat.Tranches.Add(reTran88toBBStatPost88GMP);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnStatPost88GMP);
        ReTrancheCat.Tranches.Add(reTranEqnto97StatPost88GMP);
        ReTrancheCat.Tranches.Add(reTran88toBBPost88GMPasXS1);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnPost88GMPasXS1);
        ReTrancheCat.Tranches.Add(reTranEqnto97Post88GMPasXS1);
        ReTrancheCat.Tranches.Add(reTran88toBBPost88GMPasXS2);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnPost88GMPasXS2);
        ReTrancheCat.Tranches.Add(reTranEqnto97Post88GMPasXS2);
        ReTrancheCat.Tranches.Add(reTran88toBBPost88GMPasXS3);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnPost88GMPasXS3);
        ReTrancheCat.Tranches.Add(reTranEqnto97Post88GMPasXS3);
        ReTrancheCat.Tranches.Add(reTran78to88Pre97XS1);
        ReTrancheCat.Tranches.Add(reTran78to88Pre97XS2);
        ReTrancheCat.Tranches.Add(reTran78to88Pre97XS3);
        ReTrancheCat.Tranches.Add(reTran88toBBPre97XS1);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnPre97XS1);
        ReTrancheCat.Tranches.Add(reTranEqnto97Pre97XS1);
        ReTrancheCat.Tranches.Add(reTran88toBBPre97XS2);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnPre97XS2);
        ReTrancheCat.Tranches.Add(reTranEqnto97Pre97XS2);
        ReTrancheCat.Tranches.Add(reTran88toBBPre97XS3);
        ReTrancheCat.Tranches.Add(reTranBBtoEqnPre97XS3);
        ReTrancheCat.Tranches.Add(reTranEqnto97Pre97XS3);


    }


}
