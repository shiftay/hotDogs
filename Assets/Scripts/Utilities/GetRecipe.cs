using UnityEngine;
using UnityEngine.UI;

public class GetRecipe : MonoBehaviour {
	public Text currentText;
	public Text hotDogTitle;
	Customer currCustomer;
	void OnEnable() {
		currCustomer = GameManager.Instance.CurrentCustomer.GetComponent<Customer>();
		string type;
		CreateOrder.Instance.hotDogRecipes.TryGetValue(CreateOrder.Instance.potentialHotDogs[currCustomer.hotDogChoice].type, out type);
		hotDogTitle.text = CreateOrder.Instance.potentialHotDogs[currCustomer.hotDogChoice].type;
		currentText.text = type;
	}

}
