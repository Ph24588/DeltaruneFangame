using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : MonoBehaviour {

  private static string KRIS = "kris";
  private static string SUSIE = "susie";
  private static string RALSEI = "ralsei";
	
	public enum MenuStates {
		ACTIVATE,
		WAITING,
		KRISSELECT,
		SUSIESELECT,
		RALSEISELECT,
		ACT,
		MAGICSUSIE,
		MAGICRALSEI,
		ITEMKRIS,
		ITEMSUSIE,
		ITEMRALSEI,
		HEROSELECTKRIS,
		HEROSELECTSUSIE,
		ITEMHEROSELECTRALSEI,
    MAGICHEROSELECTRALSEI,
    FIGHTENEMYSELECTKRIS,
    ACTENEMYSELECTKRIS,
    SPAREENEMYSELECTKRIS,
    FIGHTENEMYSELECTSUSIE,
    MAGICENEMYSELECTSUSIE,
    SPAREENEMYSELECTSUSIE,
    FIGHTENEMYSELECTRALSEI,
    MAGICENEMYSELECTRALSEI,
    SPAREENEMYSELECTRALSEI,
    ATTACK,
		TEXT,
		DODGE,
    END
	}
	
	public MenuStates MenuState;
  public BattleQueue BattleQueue;

  // all boxes
  GameObject NonInteractiveTextBox;
  GameObject KrisSelectBox;
  GameObject SusieSelectBox;
  GameObject RalseiSelectBox;
  GameObject KrisHeroSelectBox;
  GameObject SusieHeroSelectBox;
  GameObject RalseiHeroSelectBox;
  GameObject KrisEnemySelectBox;
  GameObject SusieEnemySelectBox;
  GameObject RalseiEnemySelectBox;
  GameObject KrisItemSelectBox;
  GameObject SusieItemSelectBox;
  GameObject RalseiItemSelectBox;
  GameObject KrisActSelectBox;
  GameObject SusieMagicSelectBox;
  GameObject RalseiMagicSelectBox;

  // scripts
  NonInteractiveTextBox NonInteractiveTextBoxScript;
  TurnSelectBox KrisSelectBoxScript;
  TurnSelectBox SusieSelectBoxScript;
  TurnSelectBox RalseiSelectBoxScript;
  HeroSelectBox KrisHeroSelectBoxScript;
  HeroSelectBox SusieHeroSelectBoxScript;
  HeroSelectBox RalseiHeroSelectBoxScript;
  EnemySelectBox KrisEnemySelectBoxScript;
  EnemySelectBox SusieEnemySelectBoxScript;
  EnemySelectBox RalseiEnemySelectBoxScript;
  ItemSelectBox KrisItemSelectBoxScript;
  ItemSelectBox SusieItemSelectBoxScript;
  ItemSelectBox RalseiItemSelectBoxScript;
  ActSelectBox KrisActSelectBoxScript;
  MagicSelectBox SusieMagicSelectBoxScript;
  MagicSelectBox RalseiMagicSelectBoxScript;

  // menu index
  int KrisSelectIndex;
  int SusieSelectIndex;
  int RalseiSelectIndex;
  int KrisHeroSelectIndex;
  int SusieHeroSelectIndex;
  int RalseiHeroSelectIndex;
  int KrisEnemySelectIndex;
  int SusieEnemySelectIndex;
  int RalseiEnemySelectIndex;
  int KrisItemSelectIndex;
  int SusieItemSelectIndex;
  int RalseiItemSelectIndex;
  int KrisActSelectIndex;
  int SusieMagicSelectIndex;
  int RalseiMagicSelectIndex;

  // Heroes
  Character Kris = new Character("Kris", 90, 90, 0, 0);
  Character Susie = new Character("Susie", 110, 110, 0, 0);
  Character Ralsei = new Character("Ralsei", 70, 70, 0, 0);

  // Enemies
  Character Seam = new Character("Seam", 100, 100, 0, 0);

  // Use this for initialization
  void Start () {
    BattleQueue = new BattleQueue();
    MenuState = MenuStates.ACTIVATE;

    NonInteractiveTextBox = GameObject.Find("BaseText");
    KrisSelectBox = GameObject.Find("KrisSelect");
    SusieSelectBox = GameObject.Find("SusieSelect");
    RalseiSelectBox = GameObject.Find("RalseiSelect");
    KrisHeroSelectBox = GameObject.Find("KrisHeroSelect");
    SusieHeroSelectBox = GameObject.Find("SusieHeroSelect");
    RalseiHeroSelectBox = GameObject.Find("RalseiHeroSelect");
    KrisEnemySelectBox = GameObject.Find("KrisEnemySelect");
    SusieEnemySelectBox = GameObject.Find("SusieEnemySelect");
    RalseiEnemySelectBox = GameObject.Find("RalseiEnemySelect");
    KrisItemSelectBox = GameObject.Find("KrisItemSelect");
    SusieItemSelectBox = GameObject.Find("SusieItemSelect");
    RalseiItemSelectBox = GameObject.Find("RalseiItemSelect");
    KrisActSelectBox = GameObject.Find("KrisActSelect");
    SusieMagicSelectBox = GameObject.Find("SusieMagicSelect");
    RalseiMagicSelectBox = GameObject.Find("RalseiMagicSelect");

    NonInteractiveTextBoxScript = NonInteractiveTextBox.GetComponent<NonInteractiveTextBox>();
    KrisSelectBoxScript = KrisSelectBox.GetComponent<TurnSelectBox>();
    SusieSelectBoxScript = SusieSelectBox.GetComponent<TurnSelectBox>();
    RalseiSelectBoxScript = RalseiSelectBox.GetComponent<TurnSelectBox>();
    KrisHeroSelectBoxScript = KrisHeroSelectBox.GetComponent<HeroSelectBox>();
    SusieHeroSelectBoxScript = SusieHeroSelectBox.GetComponent<HeroSelectBox>();
    RalseiHeroSelectBoxScript = RalseiHeroSelectBox.GetComponent<HeroSelectBox>();
    KrisEnemySelectBoxScript = KrisEnemySelectBox.GetComponent<EnemySelectBox>();
    SusieEnemySelectBoxScript = SusieEnemySelectBox.GetComponent<EnemySelectBox>();
    RalseiEnemySelectBoxScript = RalseiEnemySelectBox.GetComponent<EnemySelectBox>();
    KrisItemSelectBoxScript = KrisItemSelectBox.GetComponent<ItemSelectBox>();
    SusieItemSelectBoxScript = SusieItemSelectBox.GetComponent<ItemSelectBox>();
    RalseiItemSelectBoxScript = RalseiItemSelectBox.GetComponent<ItemSelectBox>();
    KrisActSelectBoxScript = KrisActSelectBox.GetComponent<ActSelectBox>();
    SusieMagicSelectBoxScript = SusieMagicSelectBox.GetComponent<MagicSelectBox>();
    RalseiMagicSelectBoxScript = RalseiMagicSelectBox.GetComponent<MagicSelectBox>();
  }
	
	// Update is called once per frame
	void Update () {

    // menu flow
    switch (MenuState)
    {
      // Battle starts, UI animations
      case (MenuStates.ACTIVATE):
        ////Debug.Log("ACTIVATE");
        // Display base text, load heroes and enemies
        NonInteractiveTextBoxScript.DisplayOneLine("Smells like testing...");

        // Heroes
        List<Character> Heroes = new List<Character>();
        Heroes.Add(Kris);
        Heroes.Add(Susie);
        Heroes.Add(Ralsei);
        KrisHeroSelectBoxScript.LoadHeroes(Heroes);
        SusieHeroSelectBoxScript.LoadHeroes(Heroes);
        RalseiHeroSelectBoxScript.LoadHeroes(Heroes);
        KrisSelectBoxScript.LoadHero(Kris);
        SusieSelectBoxScript.LoadHero(Susie);
        RalseiSelectBoxScript.LoadHero(Ralsei);

        // Enemies
        Character[] Enemies = new Character[] { Seam };
        KrisEnemySelectBoxScript.LoadEnemies(Enemies);
        SusieEnemySelectBoxScript.LoadEnemies(Enemies);
        RalseiEnemySelectBoxScript.LoadEnemies(Enemies);

        // Items
        List<Consumable> Items = new List<Consumable>();
        Consumable item1 = new DarkCandy();
        Consumable item2 = new DarkCandy();
        Consumable item3 = new DarkCandy();
        Consumable item4 = new DarkCandy();
        Consumable item5 = new DarkCandy();
        Consumable item6 = new DarkCandy();
        Consumable item7 = new DarkCandy();
        Consumable item8 = new DarkCandy();
        Consumable item9 = new DarkCandy();
        Items.Add(item1);
        Items.Add(item2);
        Items.Add(item3);
        Items.Add(item4);
        Items.Add(item5);
        Items.Add(item6);
        Items.Add(item7);
        Items.Add(item8);
        Items.Add(item9);
        KrisItemSelectBoxScript.InitialLoadItems(Items);
        SusieItemSelectBoxScript.InitialLoadItems(Items);
        RalseiItemSelectBoxScript.InitialLoadItems(Items);

        // Act and Magic
        List<Act> Acts = new List<Act>();
        Act act1 = new TestSoloAct();
        Act act2 = new TestDuoAct();
        Acts.Add(act1);
        Acts.Add(act2);
        KrisActSelectBoxScript.InitialLoadActs(Acts);

        List<Consumable> SusieMagic = new List<Consumable>();
        Consumable magic1 = new TestMagic();
        Consumable magic2 = new TestMagic();
        SusieMagic.Add(magic1);
        SusieMagic.Add(magic2);
        SusieMagicSelectBoxScript.InitialLoadMagic(SusieMagic);

        List<Consumable> RalseiMagic = new List<Consumable>();
        RalseiMagic.Add(magic1);
        RalseiMagic.Add(magic2);
        RalseiMagicSelectBoxScript.InitialLoadMagic(RalseiMagic);

        // Deactivate all non-text boxes
        KrisHeroSelectBox.SetActive(false);
        SusieHeroSelectBox.SetActive(false);
        RalseiHeroSelectBox.SetActive(false);
        KrisEnemySelectBox.SetActive(false);
        SusieEnemySelectBox.SetActive(false);
        RalseiEnemySelectBox.SetActive(false);
        KrisItemSelectBox.SetActive(false);
        SusieItemSelectBox.SetActive(false);
        RalseiItemSelectBox.SetActive(false);
        KrisActSelectBox.SetActive(false);
        SusieMagicSelectBox.SetActive(false);
        RalseiMagicSelectBox.SetActive(false);

        MenuState = MenuStates.KRISSELECT;
        break;
      case (MenuStates.WAITING):
        break;
      case (MenuStates.KRISSELECT):
        HandleKrisTurnSelect();
        break;
      case (MenuStates.SUSIESELECT):
        HandleSusieTurnSelect();
        break;
      case (MenuStates.RALSEISELECT):
        HandleRalseiTurnSelect();
        break;
      case (MenuStates.ACT):
        HandleKrisActSelect();
        break;
      case (MenuStates.MAGICSUSIE):
        HandleSusieMagicSelect();
        break;
      case (MenuStates.MAGICRALSEI):
        HandleRalseiMagicSelect();
        break;
      case (MenuStates.HEROSELECTKRIS):
        HandleKrisHeroSelect();
        break;
      case (MenuStates.HEROSELECTSUSIE):
        HandleSusieHeroSelect();
        break;
      case (MenuStates.ITEMHEROSELECTRALSEI):
        HandleRalseiItemHeroSelect();
        break;
      case (MenuStates.MAGICHEROSELECTRALSEI):
        HandleRalseiMagicHeroSelect();
        break;
      case (MenuStates.FIGHTENEMYSELECTKRIS):
        HandleKrisFightEnemySelect();
        break;
      case (MenuStates.ACTENEMYSELECTKRIS):
        HandleKrisActEnemySelect();
        break;
      case (MenuStates.SPAREENEMYSELECTKRIS):
        HandleKrisSpareEnemySelect();
        break;
      case (MenuStates.FIGHTENEMYSELECTSUSIE):
        HandleSusieFightEnemySelect();
        break;
      case (MenuStates.MAGICENEMYSELECTSUSIE):
        HandleSusieMagicEnemySelect();
        break;
      case (MenuStates.SPAREENEMYSELECTSUSIE):
        HandleSusieSpareEnemySelect();
        break;
      case (MenuStates.FIGHTENEMYSELECTRALSEI):
        HandleRalseiFightEnemySelect();
        break;
      case (MenuStates.MAGICENEMYSELECTRALSEI):
        HandleRalseiMagicEnemySelect();
        break;
      case (MenuStates.SPAREENEMYSELECTRALSEI):
        HandleRalseiSpareEnemySelect();
        break;
      case (MenuStates.ITEMKRIS):
        HandleKrisItemSelect();
        break;
      case (MenuStates.ITEMSUSIE):
        HandleSusieItemSelect();
        break;
      case (MenuStates.ITEMRALSEI):
        HandleRalseiItemSelect();
        break;
      case (MenuStates.ATTACK):
        break;
      case (MenuStates.TEXT):
        break;
      case (MenuStates.DODGE):
        break;
      case (MenuStates.END):
        Debug.Log("we hit the end");
        break;
    }
	}

  private void HandleKrisTurnSelect()
  {
    //Debug.Log("KRISSELECT");
    NonInteractiveTextBox.SetActive(true);
    KrisSelectBox.SetActive(true);

    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      KrisSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      KrisSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z))
    {
      KrisSelectIndex = KrisSelectBoxScript.GetIndex();
      switch (KrisSelectIndex)
      {
        case (1): // attack
          MenuState = MenuStates.FIGHTENEMYSELECTKRIS;
          break;
        case (2): // act
          MenuState = MenuStates.ACTENEMYSELECTKRIS;
          break;
        case (3): // item
          MenuState = MenuStates.ITEMKRIS;
          break;
        case (4): // spare
          MenuState = MenuStates.SPAREENEMYSELECTKRIS;
          break;
        case (5): // defend
          MenuState = MenuStates.SUSIESELECT;
          break;
      }
      StartCoroutine(TransitionBox(NonInteractiveTextBox));
    }
  }

  private void HandleSusieTurnSelect()
  {
    //Debug.Log("SUSIESELECT");
    NonInteractiveTextBox.SetActive(true);
    if (BattleQueue.GetSkipSusie())
    {
      MenuState = MenuStates.RALSEISELECT;
      return;
    }
    SusieSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      SusieSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      SusieSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z))
    {
      SusieSelectIndex = SusieSelectBoxScript.GetIndex();
      switch (SusieSelectIndex)
      {
        case (1): // attack
          MenuState = MenuStates.FIGHTENEMYSELECTSUSIE;
          break;
        case (2): // magic
          MenuState = MenuStates.MAGICSUSIE;
          break;
        case (3): // item
          MenuState = MenuStates.ITEMSUSIE;
          break;
        case (4): // spare
          MenuState = MenuStates.SPAREENEMYSELECTSUSIE;
          break;
        case (5): // defend
          MenuState = MenuStates.RALSEISELECT;
          break;
      }
      StartCoroutine(TransitionBox(NonInteractiveTextBox));
    }
  }

  private void HandleRalseiTurnSelect()
  {
    //Debug.Log("RALSEISELECT");
    NonInteractiveTextBox.SetActive(true);
    if (BattleQueue.GetSkipRalsei())
    {
      MenuState = MenuStates.END;
      return;
    }
    RalseiSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      RalseiSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      RalseiSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z))
    {
      RalseiSelectIndex = RalseiSelectBoxScript.GetIndex();
      switch (RalseiSelectIndex)
      {
        case (1): // attack
          MenuState = MenuStates.FIGHTENEMYSELECTRALSEI;
          break;
        case (2): // magic
          MenuState = MenuStates.MAGICRALSEI;
          break;
        case (3): // item
          MenuState = MenuStates.ITEMRALSEI;
          break;
        case (4): // spare
          MenuState = MenuStates.SPAREENEMYSELECTRALSEI;
          break;
        case (5): // defend
          MenuState = MenuStates.END;
          break;
      }
      StartCoroutine(TransitionBox(NonInteractiveTextBox));
    }
  }

  private void HandleKrisHeroSelect()
  {
    //Debug.Log("KRISHEROSELECT");
    KrisHeroSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      KrisHeroSelectBoxScript.DownInput();
    } else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      KrisHeroSelectBoxScript.UpInput();
    } else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character selected = KrisHeroSelectBoxScript.ZInput();
      BattleQueue.QueueItem(Kris, selected);
      KrisHeroSelectIndex = KrisHeroSelectBoxScript.GetIndex();
      MenuState = MenuStates.SUSIESELECT;
      StartCoroutine(TransitionBox(KrisHeroSelectBox));
    }
  }

  private void HandleSusieHeroSelect()
  {
    //Debug.Log("SUSIEHEROSELECT");
    SusieHeroSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      SusieHeroSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SusieHeroSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character selected = SusieHeroSelectBoxScript.ZInput();
      BattleQueue.QueueItem(Susie, selected);
      SusieHeroSelectIndex = SusieHeroSelectBoxScript.GetIndex();
      MenuState = MenuStates.RALSEISELECT;
      StartCoroutine(TransitionBox(SusieHeroSelectBox));
    }
  }

  private void HandleRalseiItemHeroSelect()
  {
    //Debug.Log("RALSEIITEMHEROSELECT");
    RalseiHeroSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiHeroSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiHeroSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character selected = RalseiHeroSelectBoxScript.ZInput();
      BattleQueue.QueueItem(Ralsei, selected);
      RalseiHeroSelectIndex = RalseiHeroSelectBoxScript.GetIndex();
      MenuState = MenuStates.END;
      StartCoroutine(TransitionBox(RalseiHeroSelectBox));
    }
  }

  private void HandleRalseiMagicHeroSelect()
  {
    //Debug.Log("RALSEIMAGICHEROSELECT");
    RalseiHeroSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiHeroSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiHeroSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character selected = RalseiHeroSelectBoxScript.ZInput();
      BattleQueue.QueueMagic(Ralsei, selected);
      RalseiHeroSelectIndex = RalseiHeroSelectBoxScript.GetIndex();
      MenuState = MenuStates.END;
      StartCoroutine(TransitionBox(RalseiHeroSelectBox));
    }
  }

  private void HandleKrisFightEnemySelect()
  {
    //Debug.Log("KRISFIGHTENEMYSELECT");
    KrisEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      KrisEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      KrisEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character enemy = KrisEnemySelectBoxScript.ZInput();
      BattleQueue.QueueFight(Kris, enemy);
      MenuState = MenuStates.SUSIESELECT;
      StartCoroutine(TransitionBox(KrisEnemySelectBox));
    }
  }

  private void HandleKrisActEnemySelect()
  {
    //Debug.Log("KRISACTENEMYSELECT");
    KrisEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      KrisEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      KrisEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      KrisEnemySelectIndex = KrisEnemySelectBoxScript.GetIndex();
      MenuState = MenuStates.ACT;
      StartCoroutine(TransitionBox(KrisEnemySelectBox));
    }
  }

  private void HandleKrisSpareEnemySelect()
  {
    //Debug.Log("KRISSPAREENEMYSELECT");
    KrisEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      KrisEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      KrisEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character enemy = KrisEnemySelectBoxScript.ZInput();
      BattleQueue.QueueSpare(Kris, enemy);
      MenuState = MenuStates.SUSIESELECT;
      StartCoroutine(TransitionBox(KrisEnemySelectBox));
    }
  }

  private void HandleSusieFightEnemySelect()
  {
    //Debug.Log("SUSIEFIGHTENEMYSELECT");
    SusieEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      SusieEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SusieEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character enemy = SusieEnemySelectBoxScript.ZInput();
      BattleQueue.QueueFight(Susie, enemy);
      MenuState = MenuStates.RALSEISELECT;
      StartCoroutine(TransitionBox(SusieEnemySelectBox));
    }
  }

  private void HandleSusieMagicEnemySelect()
  {
    //Debug.Log("SUSIEMAGICENEMYSELECT");
    SusieEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      SusieEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SusieEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character selected = SusieEnemySelectBoxScript.ZInput();
      BattleQueue.QueueMagic(Susie, selected);
      SusieEnemySelectIndex = SusieEnemySelectBoxScript.GetIndex();
      MenuState = MenuStates.RALSEISELECT;
      StartCoroutine(TransitionBox(SusieEnemySelectBox));
    }
  }

  private void HandleSusieSpareEnemySelect()
  {
    //Debug.Log("SUSIESPAREENEMYSELECT");
    SusieEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      SusieEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SusieEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character enemy = SusieEnemySelectBoxScript.ZInput();
      BattleQueue.QueueSpare(Susie, enemy);
      MenuState = MenuStates.RALSEISELECT;
      StartCoroutine(TransitionBox(SusieEnemySelectBox));
    }
  }

  private void HandleRalseiFightEnemySelect()
  {
    //Debug.Log("RALSEIFIGHTENEMYSELECT");
    RalseiEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character enemy = RalseiEnemySelectBoxScript.ZInput();
      BattleQueue.QueueFight(Ralsei, enemy);
      MenuState = MenuStates.END;
      StartCoroutine(TransitionBox(RalseiEnemySelectBox));
    }
  }

  private void HandleRalseiMagicEnemySelect()
  {
    //Debug.Log("RALSEIACTENEMYSELECT");
    RalseiEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character selected = RalseiEnemySelectBoxScript.ZInput();
      BattleQueue.QueueMagic(Ralsei, selected);
      RalseiEnemySelectIndex = RalseiEnemySelectBoxScript.GetIndex();
      MenuState = MenuStates.END;
      StartCoroutine(TransitionBox(RalseiEnemySelectBox));
    }
  }

  private void HandleRalseiSpareEnemySelect()
  {
    //Debug.Log("RALSEISPAREENEMYSELECT");
    RalseiEnemySelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiEnemySelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiEnemySelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Character enemy = RalseiEnemySelectBoxScript.ZInput();
      BattleQueue.QueueSpare(Ralsei, enemy);
      MenuState = MenuStates.END;
      StartCoroutine(TransitionBox(RalseiEnemySelectBox));
    }
  }

  private void HandleKrisItemSelect()
  {
    //Debug.Log("KRISITEMSELECT");
    KrisItemSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      KrisItemSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      KrisItemSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      KrisItemSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      KrisItemSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Consumable item = KrisItemSelectBoxScript.ZInput();
      BattleQueue.SetKrisItem(item);
      KrisItemSelectIndex = KrisItemSelectBoxScript.GetIndex(); // need to record item use
      MenuState = MenuStates.HEROSELECTKRIS;
      StartCoroutine(TransitionBox(KrisItemSelectBox));
    }
  }

  private void HandleSusieItemSelect()
  {
    //Debug.Log("SUSIEITEMSELECT");
    SusieItemSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      SusieItemSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SusieItemSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      SusieItemSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      SusieItemSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Consumable item = SusieItemSelectBoxScript.ZInput();
      BattleQueue.SetSusieItem(item);
      SusieItemSelectIndex = SusieItemSelectBoxScript.GetIndex(); // need to record item use
      MenuState = MenuStates.HEROSELECTSUSIE;
      StartCoroutine(TransitionBox(SusieItemSelectBox));
    }
  }

  private void HandleRalseiItemSelect()
  {
    //Debug.Log("RALSEIITEMSELECT");
    RalseiItemSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiItemSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiItemSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      RalseiItemSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      RalseiItemSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Consumable item = RalseiItemSelectBoxScript.ZInput();
      BattleQueue.SetRalseiItem(item);
      RalseiItemSelectIndex = RalseiItemSelectBoxScript.GetIndex(); // need to record item use
      MenuState = MenuStates.ITEMHEROSELECTRALSEI;
      StartCoroutine(TransitionBox(RalseiItemSelectBox));
    }
  }

  private void HandleKrisActSelect()
  {
    //Debug.Log("KRISACTSELECT");
    KrisActSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      KrisActSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      KrisActSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      KrisActSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      KrisActSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Act act = KrisActSelectBoxScript.ZInput();
      foreach (string actor in act.GetActors())
      {
        if (actor.Equals("Ralsei"))
        {
          BattleQueue.SetSkipRalsei(true);
        } else if (actor.Equals("Susie"))
        {
          BattleQueue.SetSkipSusie(true);
        }
      }
      KrisActSelectIndex = KrisActSelectBoxScript.GetIndex(); // need to record item use
      MenuState = MenuStates.SUSIESELECT;
      StartCoroutine(TransitionBox(KrisActSelectBox));
    }
  }

  private void HandleSusieMagicSelect()
  {
    //Debug.Log("SUSIEMAGICSELECT");
    SusieMagicSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      SusieMagicSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SusieMagicSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      SusieMagicSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      SusieMagicSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Consumable magic = SusieMagicSelectBoxScript.ZInput();
      BattleQueue.SetSusieMagic(magic);
      SusieMagicSelectIndex = SusieMagicSelectBoxScript.GetIndex(); // need to record item use
      MenuState = MenuStates.MAGICENEMYSELECTSUSIE;
      StartCoroutine(TransitionBox(SusieMagicSelectBox));
    }
  }

  private void HandleRalseiMagicSelect()
  {
    //Debug.Log("RALSEIMAGICSELECT");
    RalseiMagicSelectBox.SetActive(true);
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      RalseiMagicSelectBoxScript.DownInput();
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      RalseiMagicSelectBoxScript.UpInput();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      RalseiMagicSelectBoxScript.RightInput();
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      RalseiMagicSelectBoxScript.LeftInput();
    }
    else if (Input.GetKeyDown(KeyCode.Z)) // add to action queue
    {
      Consumable magic = RalseiMagicSelectBoxScript.ZInput();
      BattleQueue.SetRalseiMagic(magic);
      RalseiMagicSelectIndex = RalseiMagicSelectBoxScript.GetIndex(); // need to record item use
      if (magic.GetType().Equals("hero"))
      {
        MenuState = MenuStates.MAGICHEROSELECTRALSEI;
      } else
      {
        MenuState = MenuStates.MAGICENEMYSELECTRALSEI;
      }
      RalseiMagicSelectBox.SetActive(false);
      StartCoroutine(TransitionBox(RalseiMagicSelectBox));
    }
  }

  IEnumerator TransitionBox(GameObject box)
  {
    yield return new WaitForEndOfFrame();
    box.SetActive(false);
  }
}
