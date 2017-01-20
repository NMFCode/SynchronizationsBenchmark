package org.moflon.tie;

import java.io.IOException;
import org.apache.log4j.BasicConfigurator;
import org.moflon.tgg.algorithm.synchronization.SynchronizationHelper;

import org.eclipse.emf.ecore.EObject;

import FiniteStatesToPetriNets.FiniteStatesToPetriNetsPackage;


public class FiniteStatesToPetriNetsTrafo extends SynchronizationHelper{

   public FiniteStatesToPetriNetsTrafo()
   {
      super(FiniteStatesToPetriNetsPackage.eINSTANCE, ".");
   }

	public static void main(String[] args) throws IOException {
		// Set up logging
        //BasicConfigurator.configure();

		// Forward Transformation
        FiniteStatesToPetriNetsTrafo helper = new FiniteStatesToPetriNetsTrafo();
		helper.performForward("instances/fsm.xmi");
	}

	public void performForward() {
		long startTime = System.nanoTime();
		integrateForward();
		long endTime = System.nanoTime();
		System.out.println((endTime - startTime) / 1000000);

		//saveTrg("instances/fwd.trg.xmi");
		//saveCorr("instances/fwd.corr.xmi");
		//saveSynchronizationProtocol("instances/fwd.protocol.xmi");

		//System.out.println("Completed forward transformation!");
	}

	public void performForward(EObject srcModel) {
		setSrc(srcModel);
		performForward();
	}

	public void performForward(String source) {
		try {
			loadSrc(source);
			performForward();
		} catch (IllegalArgumentException iae) {
			System.err.println("Unable to load " + source + ", "
					+ iae.getMessage());
			return;
		}
	}

	public void performBackward() {
		integrateBackward();

		saveSrc("instances/bwd.trg.xmi");
		saveCorr("instances/bwd.corr.xmi");
		saveSynchronizationProtocol("instances/bwd.protocol.xmi");

		System.out.println("Completed backward transformation!");
	}

	public void performBackward(EObject targetModel) {
		setTrg(targetModel);
		performBackward();
	}

	public void performBackward(String target) {
		try {
			loadTrg(target);
			performBackward();
		} catch (IllegalArgumentException iae) {
			System.err.println("Unable to load " + target + ", "
					+ iae.getMessage());
			return;
		}
	}
}