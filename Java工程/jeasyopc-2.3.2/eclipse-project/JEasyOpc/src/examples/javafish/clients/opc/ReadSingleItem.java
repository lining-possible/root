package javafish.clients.opc;

import javafish.clients.opc.component.OpcGroup;
import javafish.clients.opc.component.OpcItem;
import javafish.clients.opc.exception.ComponentNotFoundException;
import javafish.clients.opc.exception.ConnectivityException;
import javafish.clients.opc.exception.SynchReadException;
import javafish.clients.opc.exception.UnableAddGroupException;
import javafish.clients.opc.exception.UnableAddItemException;
import javafish.clients.opc.variant.Variant;


public class ReadSingleItem {


	public  boolean ReadItem(OpcItem item) throws InterruptedException {
	  boolean flag = false;
	  
	  
	  SynchReadItemExample test = new SynchReadItemExample();
	    
	    JOpc.coInitialize();
	    
	    //JOpc jopc = new JOpc("192.168.102.11", "OPC.DeltaV.1", "JOPC1");
	    
	    //JOpc jopc = new JOpc("192.168.102.14", "SUPCON.AdvOPCServer.1", "JOPC1");
	    JOpc jopc = new JOpc("192.168.102.14", "SUPCON.JXServer.1", "");

	    //OpcItem item1 = new OpcItem("GI-3011/AI1/PV.CV", true, "");
	    //OpcItem item1 = new OpcItem("Random.Real8", true, "");
	    //OpcItem item1 = new OpcItem("Random.String", true, "");
	    
	    OpcGroup group = new OpcGroup("group1", true, 1000, 0.0f);
	    
	    group.addItem(item);
	    jopc.addGroup(group);
	    
	    try {
	      jopc.connect();
	      //System.out.println("JOPC client is connected...");
	    }
	    catch (ConnectivityException e2) {
	      e2.printStackTrace();
	    }
	    
	    try {
	      jopc.registerGroups();
	      //System.out.println("OPCGroup are registered...");
	    }
	    catch (UnableAddGroupException e2) {
	      e2.printStackTrace();
	      //System.out.println("UnableAddGroupException+"+item.getItemName());
	    }
	    catch (UnableAddItemException e2) {
	      e2.printStackTrace();
	      //System.out.println("UnableAddItemException+"+item.getItemName());
	    }
	    
	    synchronized(test) {
	      test.wait(100);
	    }
	    
	    // Synchronous reading of item
	    int cycles = 1;
	    int acycle = 0;
	    while (acycle++ < cycles) {
	      synchronized(test) {
	        test.wait(100);
	      }
	      
	      try {
	        OpcItem responseItem = jopc.synchReadItem(group, item);
	        //System.out.println(responseItem);
	        //System.out.println(responseItem.getItemName()+Variant.getVariantName(responseItem.getDataType()) + ": " + responseItem.getValue());
	        if(responseItem.getValue().getString().length()>2)
	        	flag = true;
	      }
	      catch (ComponentNotFoundException e1) {
	        e1.printStackTrace();
	        //System.out.println("ComponentNotFoundException+"+item.getItemName());
	      }
	      catch (SynchReadException e) {
	        e.printStackTrace();
	        //System.out.println("SynchReadException+"+item.getItemName());
	      }
	    }
	    
	    JOpc.coUninitialize();
	  
	  
	  
	  
	  
	  
	  return flag;}
	
}