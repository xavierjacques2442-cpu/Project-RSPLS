
    
let match = {
    playerScore: 0,
    cpuScore: 0,
    roundsNeededToWin: 0,
    gameMode: null,
    gameStarted: false
};  

const buttons = document.querySelectorAll(".buttons button");
const StartBtn = document.getElementById("startGame")
const apiUrl = "https://calm-mud-0dc7fee10.1.azurestaticapps.net";

buttons.forEach(btn => btn.disabled = true)

StartBtn.addEventListener("click", () => {
match.gameMode = document.getElementById("gameMode").value;
match.roundsNeededToWin = parseInt(document.getElementById("rounds").value);
resetMatch();
match.gameStarted = true;

buttons.forEach(btn => btn.disabled = false);

document.getElementById("result").innerText = 
match.gameMode === "cpu"
? "Game started! Play against CPU."
: "Multiplayer started! (pvp logic coming next)";
});

function play(move){
    if(!match.gameStarted) return;

    if(match.gameMode === "cpu"){
        fetch("/api/controllerone/play", {
         method: "POST",
         headers: {"Content-Type": "application/json"},
         body: JSON.stringify({move})
        })
        .then(res => res.json())
        .then(data => {
        document.getElementById("result").innerText =
        `You chose ${data.Move}, CPU chose ${data.cpuMove} → ${data.Reason}`;
        if(data.result === "win") match.playerScore++;
        if(data.result === "lose") match.cpuScore++;

        document.getElementById("score").innerText =
         `Player: ${match.playerScore} | CPU ${match.cpuScore}`;

         checkWinner();
        });
    }
}

function checkWinner(){
    if(
        match.playerScore >= match.roundsNeededToWin ||
        match.cpuScore >= match.roundsNeededToWin
    ) {
        alert(
            match.playerScore > match.cpuScore
            ? "You win the match!"
            : "CPU win the match!"
        );
        resetMatch();
    }
}

function resetMatch(){
    match.playerScore = 0;
    match.cpuScore = 0;
    match.gameStarted = false;

    document.getElementById("score").innerText = "";
    document.getElementById("result").innerText = "";

    buttons.forEach(btn => btn.disabled = true);
}

function toggleRules() {
    document.getElementById("rules").classList.toggle("hidden");
}