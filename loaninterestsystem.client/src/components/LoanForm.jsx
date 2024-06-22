import React, { useState } from 'react';
import axios from 'axios';

function LoanForm() {
    const [formData, setFormData] = useState({ clientId: '', amount: '', period: '' });
    const [result, setResult] = useState(null);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!formData.clientId || !formData.amount || !formData.period) {
            alert("All fields are required!");
            return;
        }
        try {
            const response = await axios.post('https://localhost:5001/api/loans', formData);
            setResult(response.data);
        } catch (error) {
            console.error("There was an error!", error);
            alert("Failed to get loan suggestion. Please try again.");
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="number" placeholder="Client ID" onChange={e => setFormData({ ...formData, clientId: e.target.value })} />
                <input type="number" placeholder="Loan Amount" onChange={e => setFormData({ ...formData, amount: e.target.value })} />
                <input type="number" placeholder="Period in Months" onChange={e => setFormData({ ...formData, period: e.target.value })} />
                <button type="submit">Get Loan Suggestion</button>
            </form>
            {result && <div>Total Amount: {result.totalAmount}</div>}
        </div>
    );
}

export default LoanForm;