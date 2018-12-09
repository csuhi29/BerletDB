/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.Date;

/**
 *
 * @author Csuhi
 */
public class CEG 
{

    public CEG(int CEG_ID, String CEGNEV, String SZEKHELY, int ADOSZAM, Date ALAPITAS_DATUMA, int JEGYZETT_TOKE) {
        this.CEG_ID = CEG_ID;
        this.CEGNEV = CEGNEV;
        this.SZEKHELY = SZEKHELY;
        this.ADOSZAM = ADOSZAM;
        this.ALAPITAS_DATUMA = ALAPITAS_DATUMA;
        this.JEGYZETT_TOKE = JEGYZETT_TOKE;
    }
    private int CEG_ID;
    private String CEGNEV;
    private String SZEKHELY;
    private int ADOSZAM;
    private Date ALAPITAS_DATUMA;
    private int JEGYZETT_TOKE;
}
