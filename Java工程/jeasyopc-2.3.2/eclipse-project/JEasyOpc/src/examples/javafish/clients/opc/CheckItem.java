package javafish.clients.opc;

import javafish.clients.opc.component.OpcGroup;
import javafish.clients.opc.component.OpcItem;
import javafish.clients.opc.exception.ComponentNotFoundException;
import javafish.clients.opc.exception.ConnectivityException;
import javafish.clients.opc.exception.SynchReadException;
import javafish.clients.opc.exception.UnableAddGroupException;
import javafish.clients.opc.exception.UnableAddItemException;
import javafish.clients.opc.variant.Variant;

public class CheckItem {
  public static void main(String[] args) throws InterruptedException {

    dianwei dianwei = new dianwei();
    String[] itemStrings = dianwei.items;
    String[] itemRS = new String[itemStrings.length];
    for (int i = 0; i < itemStrings.length; i++) {
    	 ReadSingleItem readSingleItem = new ReadSingleItem();
    	 
    	 if(readSingleItem.ReadItem(new OpcItem(itemStrings[i],	true,""))){
    		 //System.out.println("good"+itemStrings[i]);
    		 itemRS[i]="good"+itemStrings[i];
    		 System.out.println(i+"-"+itemStrings.length+"good");
    		 //Thread.sleep(4000);
    	 }
    	 
    	 else {
    		 //System.out.println("baad"+itemStrings[i]);
    		 itemRS[i]="baad"+itemStrings[i];
    		 System.out.println(i+"-"+itemStrings.length+"bad");
		}
	}
	System.out.println("=========================================================");
    for (int i = 0; i < itemRS.length; i++) {
    	System.out.println(itemRS[i]);
	}

  }
  
}