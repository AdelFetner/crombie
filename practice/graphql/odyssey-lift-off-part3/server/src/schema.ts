import gql from "graphql-tag";

export const typeDefs = gql`
    type Query {
        "Get tracks array for homepage grid"
        tracksForHome: [Track!]!
        "Fetch a specific track, provided a valid ID"
        track(id: ID!): Track
    }

    "A track is a group of Modules that teaches about a specific topic"
    type Track {
        id: ID!
        "The track's title"
        title: String!
        "The track's main author"
        author: Author!
        "The track's main illustration to display in track card or track page detail"
        thumbnail: String
        "The track's approximate length to complete, in minutes"
        length: Int
        "The number of modules this track contains"
        modulesCount: Int
        "The track's complete description"
        description: String
        "The number of times a track has been viewed"
        numberOfViews: Int
        "The track's complete array of modules"
        modules: [Module!]!
    }

    "Author of a complete Track"
    type Author {
        id: ID!
        "Author's first and last name"
        name: String!
        "Author's profile picture url"
        photo: String
    }

    "A Module is a single unit of teaching in a track"
    type Module {
        id: ID!
        "The module's title"
        title: String!
        "The module's length in minutes"
        length: Int
    }
`;
