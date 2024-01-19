async function generateTriangle(){
    const numberInput = document.getElementById('numberInput').value;

    if(!numberInput || isNaN(numberInput)){
        alert('Please enter a valid number!');
        return;
    }

    const resultDiv = document.getElementById('result');
    resultDiv.innerHTML = '';

    try {
        const response = await fetch(`https://localhost:44359/Triangle?number=${numberInput}`, {
            method : 'GET',
            headers : {
                'Content-Type': 'application/json',
            },
        });

        if(!response.ok){
            const errorData = await response.json();
            throw new Error(errorData.message || 'Failed to generate Triangle');
        }

        const result = await response.text();

        document.getElementById('result').innerHTML = result.replace(/\n/g, '<br>');
    }
    catch(error){
        alert(error.message);
    }
}