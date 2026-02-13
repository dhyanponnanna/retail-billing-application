// STEP 1: Import required modules
const express = require("express");
const fs = require("fs");
const cors = require("cors");
const axios = require("axios");


// STEP 2: Create Express app
const app = express();

// STEP 3: Middleware
app.use(cors());
app.use(express.json());
app.use(express.static("public"));

// STEP 4: File paths
const USERS = "users.json";
const ALCOHOLS = "alcohols.json";
const OTPS = "otp.json";

// Helper functions
function read(file, def) {
    if (!fs.existsSync(file)) return def;
    return JSON.parse(fs.readFileSync(file));
}

function write(file, data) {
    fs.writeFileSync(file, JSON.stringify(data, null, 2));
}

// STEP 5: APIs

// Get alcohol list
app.get("/api/alcohols", (req, res) => {
    res.json(read(ALCOHOLS, []));
});

// Add alcohol (admin)
app.post("/api/alcohols", (req, res) => {
    const items = read(ALCOHOLS, []);
    items.push({
        id: items.length + 1,
        name: req.body.name,
        price: Number(req.body.price)
    });
    write(ALCOHOLS, items);
    res.json({ message: "Alcohol added" });
});

// Send OTP


// Verify OTP
app.post("/api/verify-otp", (req, res) => {
    const otps = read(OTPS, {});
    if (otps[req.body.phone] == req.body.otp) {
        delete otps[req.body.phone];
        write(OTPS, otps);
        return res.json({ success: true });
    }
    res.status(400).json({ success: false });
});

// Get user
app.get("/api/user/:phone", (req, res) => {
    const users = read(USERS, []);
    const user = users.find(u => u.phone === req.params.phone);
    res.json(user || { phone: req.params.phone, points: 0 });
});

// Save user
app.post("/api/user", (req, res) => {
    const users = read(USERS, []);
    const { phone, points } = req.body;
    const u = users.find(x => x.phone === phone);
    if (u) u.points = points;
    else users.push({ phone, points });
    write(USERS, users);
    res.json({ message: "User saved" });
});

// STEP 6: Start server
app.listen(3000, () => {
    console.log("Backend running on http://localhost:3000");
});



const OTP_FILE = "otp.json";

// Send OTP


const twilio = require("twilio");


const TWILIO_SID = "";
const TWILIO_AUTH = "";
const TWILIO_PHONE = ""; // Twilio number

const twilioClient = twilio(TWILIO_SID, TWILIO_AUTH);

app.post("/api/send-otp", async (req, res) => {
    const phone = req.body.phone;
    const otp = Math.floor(1000 + Math.random() * 9000);

    // Save OTP
    const otps = read(OTPS, {});
    otps[phone] = otp;
    write(OTPS, otps);

    try {
        await twilioClient.messages.create({
            body: `Your OTP for Liquor Loyalty App is ${otp}`,
            from: TWILIO_PHONE,
            to: "+91" + phone   // India format
        });

        res.json({ message: "OTP sent via Twilio" });
    }
    catch (err) {
        console.error("Twilio error:", err.message);

        // fallback demo mode
        console.log("OTP (demo fallback):", otp);

        res.json({
            message: "OTP generated (demo fallback)"
        });
    }
});
