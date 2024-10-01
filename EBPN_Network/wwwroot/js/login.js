<><script src="https://www.gstatic.com/firebasejs/9.0.0/firebase-app.js"></script><script src="https://www.gstatic.com/firebasejs/9.0.0/firebase-auth.js"></script></>

// Initialize Firebase with your config
var firebaseConfig = {
    apiKey: "AIzaSyCKKC97I3gwKjG3Y4L9LkzU36C9zfRG4_c",
    authDomain: "ebpn-global-website.firebaseapp.com",
    projectId: "ebpn-global-website",
    storageBucket: "ebpn-global-website.appspot.com",
    messagingSenderId: "170618088622",
    appId: "1:170618088622:web:c153947918a9d21597513f",
    measurementId: "G-D3TB3Y5FTZ"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    // Post form data to the server (ASP.NET)
    fetch("/User/Login", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'X-Requested-With': 'XMLHttpRequest'
        },
        body: JSON.stringify({ email: email, password: password })
    })
        .then(response => response.json())
        .then(data => {
            if (data.token) {
                // Firebase sign in with custom token
                firebase.auth().signInWithCustomToken(data.token)
                    .then((userCredential) => {
                        // Successfully signed in, now get the ID token
                        return userCredential.user.getIdToken();
                    })
                    .then((idToken) => {
                        // Store ID token in a cookie for backend validation
                        document.cookie = `auth_token=${idToken}; path=/; Secure; HttpOnly`;

                        // Redirect or reload the page after successful login
                        window.location.href = "/";
                    })
                    .catch((error) => {
                        console.error("Error signing in with custom token:", error);
                    });
            }
        })
        .catch((error) => {
            console.error("Login failed:", error);
        });
});
