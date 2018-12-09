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
public class VASARLAS 
{
    int VASARLAS_ID;
    int DOLGOZO_ID;
    int BERLET_ID;
    String BERLET_MEGNEVEZES;
    int IGAZOLVANY_SZAM;
    Date ERVENYESSEG_KEZDETE;

    public VASARLAS(int VASARLAS_ID, int DOLGOZO_ID, int BERLET_ID, String BERLET_MEGNEVEZES, int IGAZOLVANY_SZAM, Date ERVENYESSEG_KEZDETE) {
        this.VASARLAS_ID = VASARLAS_ID;
        this.DOLGOZO_ID = DOLGOZO_ID;
        this.BERLET_ID = BERLET_ID;
        this.BERLET_MEGNEVEZES = BERLET_MEGNEVEZES;
        this.IGAZOLVANY_SZAM = IGAZOLVANY_SZAM;
        this.ERVENYESSEG_KEZDETE = ERVENYESSEG_KEZDETE;
    }
}
