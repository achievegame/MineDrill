using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Soomla.Levelup;

public class MissionHUDManager : PopUp {
	[SerializeField]
	private GameObject missionPF;
	[SerializeField]
	private Transform gridGroup;

	List<Toggle> mElmentList = new List<Toggle>();

	void Start(){
		GameObject missionGO;
		Toggle mElmnt;
		int i=0;
		int missionLimit = (int)StoreNMission.current.missionIndex.Record / StoreNMission.GROUP_LIMIT + 1;
		foreach (Mission m in StoreNMission.current.world.Missions) {
			missionGO = (GameObject)Instantiate(missionPF);
			mElmnt = missionGO.GetComponent<Toggle>();
			mElmnt.gameObject.GetComponentInChildren<Text>().text = LanguageManager.current.getSentance(m.Name,m.Description)+
				", "+LanguageManager.current.getText(LanguageNode.Prize)+": "+m.Rewards[0].Name+" "+LanguageManager.current.getText(LanguageNode.Coins);
			mElmnt.isOn = StoreNMission.current.isMissionCompleted(i);
			mElmentList.Add(mElmnt);
			missionGO.transform.SetParent(gridGroup.transform);
			missionGO.transform.localScale = Vector3.one;
			if(++i == missionLimit*StoreNMission.GROUP_LIMIT)
				break;
		}
	}
}
