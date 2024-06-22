import React, { useState } from 'react';
import axios from 'axios';

function LoanForm() {
    const [formData, setFormData] = useState({ clientId: '', amount: '', period: '' });
    const [result, setResult] = useState(null);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Convert period to integer
        const periodInMonths = parseInt(formData.period);

        // Check if required fields are filled
        if (!formData.clientId || !formData.amount || isNaN(periodInMonths)) {
            alert("All fields are required!");
            return;
        }

        try {
            const response = await axios.post('https://localhost:5001/api/loans', {
                clientId: formData.clientId,
                amount: parseFloat(formData.amount), // Ensure amount is sent as number
                periodInMonths: periodInMonths // Send parsed period as integer
            });
            setResult(response.data);
        } catch (error) {
            console.error("There was an error!", error);
            alert("Failed to get loan suggestion. Please try again.");
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="number" name="clientId" placeholder="Client ID" onChange={handleChange} value={formData.clientId} />
                <input type="number" name="amount" placeholder="Loan Amount" onChange={handleChange} value={formData.amount} />
                <input type="number" name="period" placeholder="Period in Months" onChange={handleChange} value={formData.period} />
                <button type="submit">Get Loan Suggestion</button>
            </form>
            {result && <div>Total Amount: {result.totalAmount}</div>}
        </div>
    );
}

export default LoanForm;