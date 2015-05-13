#pragma strict
#pragma downcast

//* -> Assigned in Inspector
public var CellPrefab : Transform; //*
public var GridSize : Vector3; //*

public var GridArr : Transform[,];

public var Set = new Array();
public var CompletedSet = new Array();

function Start () {
	CreateGrid();
	SetStart(0,0);
}

function CreateGrid(){ 
	var maxXZ : int = Mathf.Max(GridSize.x, GridSize.z);
	Camera.main.transform.position = Vector3(maxXZ/2f, maxXZ, maxXZ/8f);
	var x : int = GridSize.x;
	var z : int = GridSize.z;
	GridArr = new Transform[x,z];
	for(var ix = 0; ix < GridSize.x; ix++)
	{
		for(var iz = 0; iz < GridSize.z; iz++)
		{
			var newCell : Transform = 
			 Instantiate(CellPrefab, Vector3(ix,0,iz), Quaternion.identity);
			newCell.name = "("+ix+",0,"+iz+")";
			newCell.parent = transform;
			
			var newCellScript : CellScript = newCell.GetComponent("CellScript");
			newCellScript.Position = Vector3(ix,0,iz);
			
			GridArr[ix,iz] = newCell;
		}
	}
}
function SetStart(x : int, z : int){
	AddToSet(GridArr[x,z]);
}
function AddToSet(toAdd : Transform){
	toAdd.GetComponent.<Renderer>().material.color = Color.gray;
	var taScript : CellScript = toAdd.GetComponent("CellScript");
	taScript.IsOpened = true;
	Set.Unshift(toAdd);
}
var Directions : Vector3[]; //*
function FindNext(){

	if(Set.length == 0){
		Debug.Log("We're done.");
		return;
	}  
	
	var previous : Transform = Set[0]; 
	var pScript : CellScript = previous.GetComponent("CellScript");
	
	var next : Transform;
	var nextScript : CellScript;
	
	var prevX : int = pScript.Position.x; 
 	var prevZ : int = pScript.Position.z; 
 	
	var randDirection : Vector3; 
	var randSeed : int = Random.Range(0,4);
	
	var nextX : int;
	var nextZ : int; 
	var counter : int; 
	
	do{ 
		do{ 
			randDirection = Directions[randSeed];
			nextX = prevX+randDirection.x; 
			nextZ = prevZ+randDirection.z; 
			randSeed = (randSeed+1) % 4;
			counter++;
			if(counter > 4){ 
				Set.RemoveAt(0);
				previous.GetComponent.<Renderer>().material.color = Color.black;  
				yield WaitForEndOfFrame();
				return;
			}  
		}while(nextX < 0 || nextZ < 0 || nextX >= GridSize.x || nextZ >= GridSize.z); 
		next = GridArr[nextX,nextZ];
		nextScript = next.GetComponent("CellScript"); 
	}while(nextScript.IsOpened); 
	
	
	AddToSet(next); 
	
	DrawDebugLines(10, previous, next);
	
	ClearWalls(previous, next);
	
	yield WaitForEndOfFrame(); 
}
 
function DrawDebugLines(lines :int, p : Transform, n : Transform)
{
	for(var i = 0; i < lines; i++)
	{
		Debug.DrawLine(p.position, n.position, Color.magenta, 100);
	}
}

function ClearWalls(p : Transform, n : Transform) 
{
	var hitInfo : RaycastHit[]; 
	hitInfo = Physics.RaycastAll(p.position + Vector3.up, n.position - p.position, 1);
	for(var i : int = 0; i < hitInfo.length; i++) {
		Destroy(hitInfo[i].transform.gameObject);
	}
}



function Update () {
	if (Input.GetKeyDown (KeyCode.Tab) || Input.GetKey (KeyCode.Space)) {
			FindNext ();
	}

}