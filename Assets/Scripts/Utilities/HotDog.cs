
public class HotDog {

	public string type;
	public float price;
	public int ketchup, mustard, sriracha;
	public int relish, sauerkraut, onions;
	public int hotPeppers, cheese, baconBits;
	public int chili, sourCream, horseRadish;

	public HotDog() {
		Reset();
	}
	public HotDog(string name, int ket, int mus, int srir, int rel, int sauer, int onio, int hotPep, int chee, int baconB, int chil, int sCream, int horse, float dollars) {
		type = name;
		ketchup = ket;
		mustard = mus;
		sriracha = srir;
		relish = rel;
		sauerkraut = sauer;
		onions = onio;
		hotPeppers = hotPep;
		cheese = chee;
		baconBits = baconB;
		chili = chil;
		sourCream = sCream;
		horseRadish = horse;
		price = dollars;
	}
	// Update is called once per frame
	public void Reset() {
		ketchup = 0;
		mustard = 0;
		sriracha = 0;
		relish = 0;
		chili = 0;
		sourCream = 0;
		cheese = 0;
		baconBits = 0;
		horseRadish = 0;
		hotPeppers = 0;
		onions = 0;
		sauerkraut = 0;
	}

	public static bool operator == (HotDog x, HotDog y) {
		if(x.ketchup == y.ketchup && x.mustard == y.mustard && x.sriracha == y.sriracha &&
		   x.relish == y.relish && x.sauerkraut == y.sauerkraut && x.onions == y.onions &&
		   x.hotPeppers == y.hotPeppers && x.cheese == y.cheese && x.baconBits == y.baconBits &&
		   x.chili == y.chili && x.sourCream == y.sourCream && x.horseRadish == y.horseRadish) {
			   return true;
		   } else
		   	   return false;
	}

	public static bool operator != (HotDog x, HotDog y) {
		if(x.ketchup == y.ketchup && x.mustard == y.mustard && x.sriracha == y.sriracha &&
		   x.relish == y.relish && x.sauerkraut == y.sauerkraut && x.onions == y.onions &&
		   x.hotPeppers == y.hotPeppers && x.cheese == y.cheese && x.baconBits == y.baconBits &&
		   x.chili == y.chili && x.sourCream == y.sourCream && x.horseRadish == y.horseRadish) {
			   return false;
		   } else
		   	   return true;
	}
}
