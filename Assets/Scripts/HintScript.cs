using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScript : MonoBehaviour
{
	//kintamieji
	public bool kintamasis1;    //True arba False  1 arba 0
	public int kintamasis2;     //Sveikieji skaiciai be kableliu
	public List<int> kintamasis3;   //Laiko savyje daug int tipo kintamuju
	public int[] kintamasis4;       //Laiko savyje daug int tipo kintamuju
	public GameObject kintamasis5;  //GameObjectai kurie yra scenoje (arba ne tik)

	//funkcijos
	public void A() { }	//negrazins rezultato
	public bool B() { return false; }		//grazins true/false
	public IEnumerator C() { return null; } //Asinchroniniai dalykai

	public void StandartinesUnityFuncijos()
	{
		var rezultatas1 = gameObject.GetComponent<Rigidbody>();	//bandys surasti Rigidbody kintamaji VISADA
																//ant to GameObjecto ant kurio sitas skriptas yra uzdragintas
	}


	private void Start()
	{
		DelegatuTestas();
	}

	public Action callback;
	private void DelegatuTestas()	//Iskviesta sita funckija isprintins tokia eiles tvarka 1 3 2
	{
		print("1");
		callback += D;
		if (callback != null)
		{
			callback();
		}
		print("2");
	}

	public void D()
	{
		print("3");
	}


	private void KoroutinuTestas()	//
	{
		StartCoroutine(IEnumeratoriausTestas());
	}

	private IEnumerator IEnumeratoriausTestas()
	{
		print(1);
		yield return null;  //palaukia viena frame
		yield return new WaitForSeconds(5);	//palauks 5 sekundes
		print(2);
	}
}
