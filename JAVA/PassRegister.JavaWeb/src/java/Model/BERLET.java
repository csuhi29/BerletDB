/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 *
 * @author Csuhi
 */
public class BERLET 
{

    public BERLET(int BERLET_ID, String MEGNEVEZES, int AR, int ERVENYESSEG_IDO, String KEDVEZMENY_TIPUS, String BERLET_FORMATUM) {
        this.BERLET_ID = BERLET_ID;
        this.MEGNEVEZES = MEGNEVEZES;
        this.AR = AR;
        this.ERVENYESSEG_IDO = ERVENYESSEG_IDO;
        this.KEDVEZMENY_TIPUS = KEDVEZMENY_TIPUS;
        this.BERLET_FORMATUM = BERLET_FORMATUM;
    }
    private int BERLET_ID;
    private String MEGNEVEZES;
    private int AR;
    private int ERVENYESSEG_IDO;
    private String KEDVEZMENY_TIPUS;
    private String BERLET_FORMATUM;
    
    
}
