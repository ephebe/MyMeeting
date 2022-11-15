CREATE VIEW [v_meeting_group_proposals]
AS
SELECT
    [meeting_group_proposal].[id],
    [meeting_group_proposal].[name],
    [meeting_group_proposal].[description],
    [meeting_group_proposal].[location_city],
    [meeting_group_proposal].[location_country_code],
    [meeting_group_proposal].[proposal_user_id],
    [meeting_group_proposal].[proposal_date],
    [meeting_group_proposal].[status_code],
    [meeting_group_proposal].[decision_date],
    [meeting_group_proposal].[decision_user_id],
    [meeting_group_proposal].[decision_code],
    [meeting_group_proposal].[decision_reject_reason]
FROM [meeting_group_proposals] AS [meeting_group_proposal]