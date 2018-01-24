//$(document).ready(function () {
   

var player = new PlayerPos(-1, -1);

document.getElementById("restartGame").onclick = reload;
document.getElementById("newGame").onclick = newGame;

var goalList = [];

drawMap();


function drawMap()
{
	var map = document.getElementById("mapHere");
	goalList = [];
	for(var y = 0; y < 16; y++ )
	{
		
		for(var x = 0; x < 19; x++ )
		{
			var tile = document.createElement("div");
			
			if(tileMap.mapGrid[y][x] == "P")
			{
				tile.classList.add("player"); 				// add css class "player" to the element
				tile.classList.add("emptyBlock"); 			// add css class "emptyBlock" to the element
				player.y = y;
				player.x = x;
			}
			
			else if(tileMap.mapGrid[y][x] == "W")
			{
				tile.classList.add("wall");					// add css class "wall" to the element
			}
			
			else if(tileMap.mapGrid[y][x] == "B")
			{
				tile.classList.add("movableBlock");			// add css class "movableBlock" to the element
				tile.classList.add("emptyBlock"); 			// add css class "emptyBlock" to the element
			}
			
			else if(tileMap.mapGrid[y][x] == "G")
			{
				tile.classList.add("goal");					// add css class "goal" to the element
				goalList.push(tile);
			}
			
			else if(tileMap.mapGrid[y][x] == "F")
			{
				tile.classList.add("forest");				// add css class "forest" to the element
			}
			
			else
			{
				tile.classList.add("emptyBlock");			// add css class "emptyBlock" to the element
			}
			
			tile.setAttribute("Id", (y + ',' + x));
			map.appendChild(tile);
		}
		
	}
}

function PlayerPos(x, y) {
	this.x = x;
	this.y = y;
}

function TheKey(event)										// Arrow keys input
{
	if(event.keyCode == 37)									// Left
		{
		event.preventDefault();
		var newPosX = player.x - 1;
		var newPosY = player.y;
		var newNewPosX = player.x - 2;
		var newNewPosY = player.y;
		move(newPosX, newPosY, newNewPosX, newNewPosY);
		}
	
	else if(event.keyCode == 38)							// Up
		{
		event.preventDefault();
		var newPosX = player.x;
		var newPosY = player.y - 1;
		var newNewPosX = player.x;
		var newNewPosY = player.y - 2;
		move(newPosX, newPosY, newNewPosX, newNewPosY);
		}
	
	else if(event.keyCode == 39)							// Right
		{
		event.preventDefault();
		var newPosX = player.x + 1;
		var newPosY = player.y;
		var newNewPosX = player.x + 2;
		var newNewPosY = player.y;
		move(newPosX, newPosY, newNewPosX, newNewPosY);
		}
	
	else if(event.keyCode == 40)							// Down
		{
		event.preventDefault();
		var newPosX = player.x;
		var newPosY = player.y + 1;
		var newNewPosX = player.x;
		var newNewPosY = player.y + 2;
		move(newPosX, newPosY, newNewPosX, newNewPosY);
		}
}

function move(newPosX, newPosY, newNewPosX, newNewPosY)

{
	var playerElem = document.getElementById(player.y + "," + player.x);
	var nextElem = document.getElementById(newPosY + "," + newPosX);
	var nextNextElem = document.getElementById(newNewPosY + "," + newNewPosX);
	
	if(nextElem.classList.contains("wall"))
	{

	}
	
	else if(nextElem.classList.contains("movableBlock"))
		{
			if(nextNextElem.classList.contains("wall"))
				{
					
				}
			
			else if(nextNextElem.classList.contains("movableBlock"))
				
				{
					
				}
			
			else if(nextNextElem.classList.contains("goal"))
				
				{
				playerElem.classList.remove("player");
				nextElem.classList.add("player");
				player.x = newPosX;
				player.y = newPosY;
				nextElem.classList.remove("movableBlock");
				nextNextElem.classList.add("movableBlock");
				}
			
			else if(nextNextElem.classList.contains("forest"))
				
				{
				
				}
			
			else
				{
				playerElem.classList.remove("player");
				nextElem.classList.add("player");
				player.x = newPosX;
				player.y = newPosY;
				nextElem.classList.remove("movableBlock");
				nextNextElem.classList.add("movableBlock");
				}
		}
		
	else
	{
		playerElem.classList.remove("player");
		nextElem.classList.add("player");
		player.x = newPosX;
		player.y = newPosY;
	}
		checkGoal();
}

function reload()
{
	var map = document.getElementById("mapHere");
	map.innerHTML = "";
	jQuery('#hid').hide()
	drawMap();
}

function newGame()
{
	var map = document.getElementById("mapHere");
	map.innerHTML = "";
	if (jQuery('#hid').show = true)
		{
		jQuery('#hid').hide();
		}
		
	tileMap = mapsArray[Math.floor(Math.random() * mapsArray.length)];
	drawMap();
}

function checkGoal()
{
	var done = true;
	for (var i=0; i < goalList.length; i++)
	{
		if(!goalList[i].classList.contains("movableBlock"))
			
		{
			done = false;
			break;
		}
		
		
	}	
	
		if(done)
		{
			jQuery('#hid').show();
}	
}
//});