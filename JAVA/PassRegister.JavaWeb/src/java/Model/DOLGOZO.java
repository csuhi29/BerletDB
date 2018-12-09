/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author Csuhi
 */
public class DOLGOZO 
{

    public DOLGOZO(int DOLGOZO_ID, int CEG_ID, String NEV, String NEM, String SZULETESI_HELY, int SZULETESI_EV, int IGAZOLVANY_SZAM) {
        this.DOLGOZO_ID = DOLGOZO_ID;
        this.CEG_ID = CEG_ID;
        this.NEV = NEV;
        this.NEM = NEM;
        this.SZULETESI_HELY = SZULETESI_HELY;
        this.SZULETESI_EV = SZULETESI_EV;
        this.IGAZOLVANY_SZAM = IGAZOLVANY_SZAM;
    }
    private int DOLGOZO_ID;
    private int CEG_ID;
    private String NEV;
    private String NEM;
    private String SZULETESI_HELY;
    private int SZULETESI_EV;
    private int IGAZOLVANY_SZAM;
}
