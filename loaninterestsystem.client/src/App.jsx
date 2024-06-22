import React from 'react';
import LoanForm from './components/LoanForm';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <h1>Loan Calculator</h1>
            </header>
            <main>
                <LoanForm />
            </main>
        </div>
    );
}

export default App;