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
public class BerletMethods 
{

    public BerletMethods() {
    }
    
    public String KedvezmenyGenerator(){
        Random rnd = new Random();
        List<String> sale = new ArrayList<>();
        sale.add("diák");
        sale.add("nincs");
        sale.add("nyugdíjas");
        sale.add("alkalmi");
        String valami = sale.get(rnd.nextInt(sale.size()));
        return valami;
    }
    
    public String FormatumGenerator()
    {
        Random rnd = new Random();
        List<String> format = new ArrayList<>();
        format.add("papír");
        format.add("online");
        format.add("papír/online");
        return format.get(rnd.nextInt(format.size()));
    }
}
