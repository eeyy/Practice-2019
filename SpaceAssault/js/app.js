
// A cross-browser requestAnimationFrame
// See https://hacks.mozilla.org/2011/08/animating-with-javascript-from-setinterval-to-requestanimationframe/
var requestAnimFrame = (function(){
    return window.requestAnimationFrame       ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame    ||
        window.oRequestAnimationFrame      ||
        window.msRequestAnimationFrame     ||
        function(callback){
            window.setTimeout(callback, 1000 / 60);
        };
})();

// Create the canvas
var canvas = document.createElement("canvas");
var ctx = canvas.getContext("2d");
canvas.width = 512;
canvas.height = 480;
document.body.appendChild(canvas);

// The main game loop
var lastTime;
function main() {
    var now = Date.now();
    var dt = (now - lastTime) / 1000.0;

    update(dt);
    render();

    lastTime = now;
    requestAnimFrame(main);
};

function init() {
    terrainPattern = ctx.createPattern(resources.get('img/terrain.png'), 'repeat');

    document.getElementById('play-again').addEventListener('click', function() {
        reset();
    });

    reset();
    lastTime = Date.now();
    main();
}

resources.load([
    'img/sprites.png',
    'img/terrain.png'
]);
resources.onReady(init);


// Game state //

var player = {
    pos: [0, 0],
    sprite: new Sprite('img/sprites.png', [0, 0], [39, 39], 16, [0, 1])
};

var bullets = [];
var enemies = [];
var explosions = [];
var megaliths = [];
var manna = [];
var arrManna = [];

var lastFire = Date.now();
var gameTime = 0;
var isGameOver;
var terrainPattern;
var countMegaliths = randomInteger(4, 8);
var countManna = randomInteger(4, 12);
var checkedManna = [];
var posNewManna = [];

var score = 0;
var scoreManna = 0;
var scoreEl = document.getElementById('score');
var scoreMa = document.getElementById('manna');

// Speed in pixels per second
var playerSpeed = 200;
var bulletSpeed = 500;
var enemySpeed = 100;


function randomInteger(min, max) {
    var rand = min - 0.5 + Math.random() * (max - min + 1)
    rand = Math.round(rand);
    return rand;
 }


// Update game objects
function update(dt) {
    gameTime += dt;   

    handleInput(dt);
    updateEntities(dt);
    //add manna to the map
    updateManna();

    // It gets harder over time by adding enemies using this
    // equation: 1-.993^gameTime
    if(Math.random() < 1 - Math.pow(.993, gameTime)) {
        enemies.push({
            pos: [canvas.width,
                  Math.random() * (canvas.height - 39)],
            sprite: new Sprite('img/sprites.png', [0, 78], [80, 39],
                               6, [0, 1, 2, 3, 2, 1])
        });
    }

    

	//add megaliths to the map
	if(megaliths.length < countMegaliths) {
        megaliths.push({
            pos: [Math.random() * (canvas.width - 55),
                  Math.random() * (canvas.height - 53)],
            sprite: new Sprite('img/sprites.png', [3, 213], [55, 53])
        });
    }
	
	if(megaliths.length < countMegaliths) {
        megaliths.push({
            pos: [Math.random() * (canvas.width - 48),
                  Math.random() * (canvas.height - 42)],
            sprite: new Sprite('img/sprites.png', [5, 274], [48, 42])
        });
    }
    
    checkCollisions();
    updateManna();
    scoreEl.innerHTML = score;
    scoreMa.innerHTML = scoreManna;
};

function updateManna(){
    
    if(manna.length == 0){
        manna.push({
            pos: [Math.random() * (canvas.width - 57),
             Math.random() * (canvas.height - 39)],
            sprite: new Sprite('img/sprites.png', [0, 164], [57, 39], 3, [0, 1])
        });
    }
    else{
        if(manna.length < countManna) {
            manna.push({
                pos: createPosNewManna(),
                sprite: new Sprite('img/sprites.png', [0, 164], [57, 39], 3, [0, 1])
            });
        }
    }
};

function createPosNewManna(){
    while( true ){
        var x = Math.random() * (canvas.width - 57);
        var y = Math.random() * (canvas.height - 39);
        var posNewManna = [x, y];
        var xSize = x + 57;
        var ySize = y + 39;
        var sizeNewManna = [xSize, ySize];
        
        if(checkPosNewManna(posNewManna, sizeNewManna, manna) & checkPosNewManna(posNewManna, sizeNewManna, megaliths)){
            return posNewManna;
        }

/*
        for(var i=0; i<manna.length; i++){
            var pos = manna[i].pos;
            var size = manna[i].sprite.size;
            if (boxCollides(posNewManna, sizeNewManna, pos, size)){
                break;
            }
            else{
                if (i == manna.length - 1){
                n++;
                }
            }
        }

        for(var i=0; i<megaliths.length; i++){
            var pos = megaliths[i].pos;
            var size = megaliths[i].sprite.size;
            if (boxCollides(posNewManna, sizeNewManna, pos, size)){
                break;
            }
            else{
                if (i == megaliths.length - 1){
                    n++;
                }
            }
        }
        if (n == 2){
            return posNewManna;
        }*/
    }
}

function checkPosNewManna(posNewManna, sizeNewManna, arr){
    for(var i=0; i<arr.length; i++){
        var pos = arr[i].pos;
        var size = arr[i].sprite.size;
        if (boxCollides(posNewManna, sizeNewManna, pos, size)){
            break;
        }
        else{
            if (i == arr.length - 1){
                return true;
            }
        }
    }
    return false;
}


function handleInput(dt) {
    if(input.isDown('DOWN') || input.isDown('s')) {
        player.pos[1] += playerSpeed * dt;
    }

    if(input.isDown('UP') || input.isDown('w')) {
        player.pos[1] -= playerSpeed * dt;
    }

    if(input.isDown('LEFT') || input.isDown('a')) {
        player.pos[0] -= playerSpeed * dt;
    }

    if(input.isDown('RIGHT') || input.isDown('d')) {
        player.pos[0] += playerSpeed * dt;
    }

    if(input.isDown('SPACE') &&
       !isGameOver &&
       Date.now() - lastFire > 100) {
        var x = player.pos[0] + player.sprite.size[0] / 2;
        var y = player.pos[1] + player.sprite.size[1] / 2;

        bullets.push({ pos: [x, y],
                       dir: 'forward',
                       sprite: new Sprite('img/sprites.png', [0, 39], [18, 8]) });
        bullets.push({ pos: [x, y],
                       dir: 'up',
                       sprite: new Sprite('img/sprites.png', [0, 50], [9, 5]) });
        bullets.push({ pos: [x, y],
                       dir: 'down',
                       sprite: new Sprite('img/sprites.png', [0, 60], [9, 5]) });

        lastFire = Date.now();
    }
}

function updateEntities(dt) {
    // Update the player sprite animation
    player.sprite.update(dt);

    // Update all the bullets
    for(var i=0; i<bullets.length; i++) {
        var bullet = bullets[i];

        switch(bullet.dir) {
        case 'up': bullet.pos[1] -= bulletSpeed * dt; break;
        case 'down': bullet.pos[1] += bulletSpeed * dt; break;
        default:
            bullet.pos[0] += bulletSpeed * dt;
        }

        // Remove the bullet if it goes offscreen
        if(bullet.pos[1] < 0 || bullet.pos[1] > canvas.height ||
           bullet.pos[0] > canvas.width) {
            bullets.splice(i, 1);
            i--;
        }
    }

    // Update all the enemies
    for(var i=0; i<enemies.length; i++) {
        enemies[i].pos[0] -= enemySpeed * dt;
        enemies[i].sprite.update(dt);

        // Remove if offscreen
        if(enemies[i].pos[0] + enemies[i].sprite.size[0] < 0) {
            enemies.splice(i, 1);
            i--;
        }
    }

    // Update all the explosions
    for(var i=0; i<explosions.length; i++) {
        explosions[i].sprite.update(dt);

        // Remove if animation is done
        if(explosions[i].sprite.done) {
            explosions.splice(i, 1);
            i--;
        }
    }

    // Update all the megaliths
    for(var i=0; i<megaliths.length; i++) {
        megaliths[i].sprite.update(dt);
    }

    // Update all the manna
    for(var i=0; i<manna.length; i++) {
        manna[i].sprite.update(dt);

        // Remove if animation is done
        if(manna[i].sprite.done) {
            manna.splice(i, 1);
            i--;
        }
    }
}

// Collisions

function collides(x, y, r, b, x2, y2, r2, b2) {
    return !(r <= x2 || x > r2 ||
             b <= y2 || y > b2);
}

function boxCollides(pos, size, pos2, size2) {
    return collides(pos[0], pos[1],
                    pos[0] + size[0], pos[1] + size[1],
                    pos2[0], pos2[1],
                    pos2[0] + size2[0], pos2[1] + size2[1]);
}

function checkCollisions() {
    checkPlayerBounds();
    
    checkPlayerMegaliths();
    checkEnemiesMegaliths();
    checkBulletsMegaliths();
    checkPlayerManna();

    // Run collision detection for all enemies and bullets
    for(var i=0; i<enemies.length; i++) {
        var pos = enemies[i].pos;
        var size = enemies[i].sprite.size;

        for(var j=0; j<bullets.length; j++) {
            var pos2 = bullets[j].pos;
            var size2 = bullets[j].sprite.size;

            if(boxCollides(pos, size, pos2, size2)) {
                // Remove the enemy
                enemies.splice(i, 1);
                i--;

                // Add score
                score += 100;

                // Add an explosion
                explosions.push({
                    pos: pos,
                    sprite: new Sprite('img/sprites.png',
                                       [0, 117],
                                       [39, 39],
                                       16,
                                       [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                                       null,
                                       true)
                });

                // Remove the bullet and stop this iteration
                bullets.splice(j, 1);
                break;
            }
        }

        if(boxCollides(pos, size, player.pos, player.sprite.size)) {
            gameOver();
        }

    }
}

function checkPlayerMegaliths(){
    for(var i=0; i<megaliths.length; i++) {
        var posMeg = megaliths[i].pos;
        var sizeMeg = megaliths[i].sprite.size;
        
        if(boxCollides(posMeg, sizeMeg, player.pos, player.sprite.size)) {
            if(player.pos[0] < posMeg[0]){
            player.pos[0] = player.pos[0] - 8;
            }
            if(player.pos[1] < posMeg[1]){
            player.pos[1] = player.pos[1] - 8;
            }
            if(player.pos[0] > posMeg[0]){
                player.pos[0] = player.pos[0] + 8;
            }
            if(player.pos[1] > posMeg[1]){
                player.pos[1] = player.pos[1] + 8;
            }
        }
    }
}
function checkEnemiesMegaliths(){
    for(var i=0; i<megaliths.length; i++) {
        var posMeg = megaliths[i].pos;
        var sizeMeg = megaliths[i].sprite.size;

        for(var j=0; j<enemies.length; j++) {
            var pos = enemies[j].pos;
            var size = enemies[j].sprite.size;
            if(boxCollides(posMeg, sizeMeg, pos, size)) {
                if(pos[1] < posMeg[1]){
                pos[1] = pos[1] - 8;
                }
                if(pos[0] > posMeg[0]){
                    pos[0] = pos[0] + 8;
                }
                if(pos[1] > posMeg[1]){
                    pos[1] = pos[1] + 8;
                }
            }
        }
    }
}

function checkBulletsMegaliths(){
    for(var i=0; i<megaliths.length; i++) {
        var posMeg = megaliths[i].pos;
        var sizeMeg = megaliths[i].sprite.size;

        for(var j=0; j<bullets.length; j++) {
            var pos = bullets[j].pos;
            var size = bullets[j].sprite.size;
            if(boxCollides(posMeg, sizeMeg, pos, size)) {
                bullets.splice(j, 1);
            }
        }
    }
}

var a = 0;
var b = 0;
function checkPlayerManna(){
    
    for(var i=0; i<manna.length; i++) {
        var posManna = manna[i].pos;
        var sizeManna = manna[i].sprite.size;
        

            if(boxCollides(posManna, sizeManna, player.pos, player.sprite.size) & (checkedManna != posManna) & (a == b)){// & (qwe[0] < (player.pos[0] + 15) | qwe[0] < (player.pos[0] - 15)))  {
                a++;
                checkedManna = posManna;
                manna.splice(i, 1);
                
                //add manna to the map
                updateManna();
                
                scoreManna++;
                // Add new manna
                manna.push({
                    pos: checkedManna,
                    sprite: new Sprite('img/sprites.png', [0, 164], [57, 39], 8, [1, 2, 3], null, true)
                });
                b++;
                break;

            }
        
    }
}



function checkPlayerBounds() {
    // Check bounds
    if(player.pos[0] < 0) {
        player.pos[0] = 0;
    }
    else if(player.pos[0] > canvas.width - player.sprite.size[0]) {
        player.pos[0] = canvas.width - player.sprite.size[0];
    }

    if(player.pos[1] < 0) {
        player.pos[1] = 0;
    }
    else if(player.pos[1] > canvas.height - player.sprite.size[1]) {
        player.pos[1] = canvas.height - player.sprite.size[1];
    }
}

// Draw everything
function render() {
    ctx.fillStyle = terrainPattern;
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // Render the player if the game isn't over
    if(!isGameOver) {
        renderEntity(player);
    }

    renderEntities(bullets);
    renderEntities(enemies);
    renderEntities(explosions);
    renderEntities(megaliths);
    renderEntities(manna);
};

function renderEntities(list) {
    for(var i=0; i<list.length; i++) {
        renderEntity(list[i]);
    }    
}

function renderEntity(entity) {
    ctx.save();
    ctx.translate(entity.pos[0], entity.pos[1]);
    entity.sprite.render(ctx);
    ctx.restore();
}

// Game over
function gameOver() {
    document.getElementById('game-over').style.display = 'block';
    document.getElementById('game-over-overlay').style.display = 'block';
    isGameOver = true;
}

// Reset game to original state
function reset() {
    document.getElementById('game-over').style.display = 'none';
    document.getElementById('game-over-overlay').style.display = 'none';
    isGameOver = false;
    gameTime = 0;
    score = 0;
    scoreManna = 0;
    countMegaliths = randomInteger(4, 8);
    countManna = randomInteger(4, 12);

    enemies = [];
    bullets = [];
    megaliths = [];
    
    player.pos = [50, canvas.height / 2];
};
