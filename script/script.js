
    
let match = {
    playerScore: 0,
    cpuScore: 0,
    roundsNeededToWin: 3
};  



  const apiUrl = "https://rpslspjxj26-apevc8dpdchjdqbz.westus3-01.azurewebsites.net";
function play(move) {
    match.roundsNeededToWin = parseInt(document.getElementById("rounds").value);
    fetch("/api/controllerone/play", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({move})
    })

    .then(res => res.json())
    .then((data) => 
    {
     document.getElementById("result").innerText =
                `You chose ${data.Move}, CPU chose ${data.cpuMove} → ${data.Reason}`;

            if (data.result === "win") match.playerScore++;
            if (data.result === "lose") match.cpuScore++;

            document.getElementById("score").innerText =
                `Player: ${match.playerScore} | CPU: ${match.cpuScore}`;

            if (match.playerScore >= match.roundsNeededToWin ||
                match.cpuScore >= match.roundsNeededToWin) {

                alert(match.playerScore > match.cpuScore ? "YOU WIN THE MATCH!" : "CPU WINS THE MATCH!");
                resetMatch();
            }
        });
    }

    function resetMatch() {
        match.playerScore = 0;
        match.cpuScore = 0;
        document.getElementById("score").innerText = "";
        document.getElementById("result").innerText = "";
    }

    function toggleRules() {
        const rules = document.getElementById("rules");
      rules.classList.toggle("hidden");
    }

    function resetMatch(){
    match.playerScore = 0;
    match.cpuScore = 0;
    document.getElementById("score").innerText = "";
    document.getElementById("result").innerText = "";
    }