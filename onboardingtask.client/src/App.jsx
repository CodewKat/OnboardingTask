import './App.css';
import CustomerList from './components/CustomerList';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <h1>Welcome to My Customer App</h1>
            </header>
            <main>
                <CustomerList />
            </main>
        </div>
    );
}

export default App;