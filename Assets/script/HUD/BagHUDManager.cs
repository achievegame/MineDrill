using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagHUDManager : PopUp {
	[SerializeField]
	private GameObject bagEPF;
	[SerializeField]
	private Transform grid;
	[SerializeField]
	private Sprite[] toolSpr;

	private List<BagHUDElement> bagEs = new List<BagHUDElement>(16);
	void Start(){
		makeGrid ();
	}

	void makeGrid(){
		GameControl.current.refreashBag ();

		BagHUDElement bHE;
		GameObject bEGO;
		BagElement bE;
		for (int i=0; i<16; i++) {
			bEGO = Instantiate<GameObject>(bagEPF);
			bEGO.transform.SetParent(grid);
			bEGO.transform.localScale = Vector3.one;
			bHE = bEGO.GetComponent<BagHUDElement>();
			bE	=	GameControl.current.bagL[i];
			if(bE.bagEType.Equals(BagElementType.Tools)){
				bHE.init(toolSpr[bE.elementTypeIndex],bE.count);
			}else if(!bE.isLocked && bE.count > 0){
				bHE.init(BrickManager.current.Minerals[bE.elementTypeIndex], bE.count);
			}else{
				bHE.init(bE.isLocked);
			}

			bagEs.Add(bHE);
		}
	}
}

public enum BagElementType{
	Tools,
	Minerals
}

public class BagElement{
	public bool isLocked=true;
	public BagElementType bagEType=BagElementType.Minerals;
	public int elementTypeIndex=-1;
	public int count=0;
}
