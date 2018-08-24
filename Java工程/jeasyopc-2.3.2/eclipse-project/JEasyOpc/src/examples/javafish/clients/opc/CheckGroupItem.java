package javafish.clients.opc;

import java.util.ArrayList;

import javafish.clients.opc.dianwei;
import javafish.clients.opc.component.OpcGroup;
import javafish.clients.opc.component.OpcItem;
import javafish.clients.opc.exception.CoInitializeException;
import javafish.clients.opc.exception.CoUninitializeException;
import javafish.clients.opc.exception.ComponentNotFoundException;
import javafish.clients.opc.exception.ConnectivityException;
import javafish.clients.opc.exception.SynchReadException;
import javafish.clients.opc.exception.UnableAddGroupException;
import javafish.clients.opc.exception.UnableAddItemException;

public class CheckGroupItem {
  public static void main(String[] args) throws InterruptedException {
    SynchReadGroupExample test = new SynchReadGroupExample();
    
    try {
      JOpc.coInitialize();
    }
    catch (CoInitializeException e1) {
      e1.printStackTrace();
    }
    

    JOpc jopc = new JOpc("192.168.102.14", "SUPCON.JXServer.1", "");
   // JOpc jopc = new JOpc("192.168.102.11", "OPC.DeltaV.1", "JOPC1");

    OpcGroup[] groups = new OpcGroup[10];
    for (int i = 0; i < groups.length; i++) {
    	groups[i] = new OpcGroup("group"+String.valueOf(i), true, 5000, 0.0f);
	}
    
 
    
    dianwei dianwei = new dianwei();
    String[] items = dianwei.items;

    int itemsI = 0;
    while (itemsI < items.length) {
        for (int i = 0; i < 10; i++) {
        	if(itemsI < items.length){
        		groups[i].addItem(new OpcItem(items[itemsI], true,""));
        	}
    		itemsI++;
    	}
	}
    for (int i = 0; i < groups.length; i++) {
    	jopc.addGroup(groups[i]);;
	}

    
    try {
      jopc.connect();
      System.out.println("JOPC client is connected...");
    }
    catch (ConnectivityException e2) {
      e2.printStackTrace();
    }
    
    try {
      jopc.registerGroups();
      System.out.println("OPCGroup are registered...");
    }
    catch (UnableAddGroupException e2) {
      e2.printStackTrace();
    }
    catch (UnableAddItemException e2) {
      e2.printStackTrace();
    }
    
    synchronized(test) {
      test.wait(1000);
    }
    
    // Synchronous reading of group
    int cycles = 10;
    int acycle = 0;
    while (acycle++ < cycles) {
      synchronized(test) {
        test.wait(5001);
      }
      
      try {
    	    for (int i = 0; i < groups.length; i++) {
    	        OpcGroup responseGroup = jopc.synchReadGroup(groups[i]);
    	        System.out.println("สýพÝื้"+String.valueOf(i));
    	        ArrayList<OpcItem> opcItems = responseGroup.getItems();
    	        for (OpcItem opcItem : opcItems) {
    	            System.out.println(opcItem.getItemName() + ":" + opcItem.getValue());
    	        }
    		}


      }
      catch (ComponentNotFoundException e1) {
        e1.printStackTrace();
      }
      catch (SynchReadException e1) {
        e1.printStackTrace();
      }
    }
    
    try {
      JOpc.coUninitialize();
    }
    catch (CoUninitializeException e) {
      e.printStackTrace();
    }
  }
}
